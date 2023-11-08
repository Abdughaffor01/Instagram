using AutoMapper;
using Domain.DTOs.PostDTOs;
using Infrastructure.Data;
using Infrastructure.Services.FileServices;

namespace Infrastructure.Services.PostServices;

public class PostService : IPostService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IFileService _fileService;

    public PostService(DataContext context, IMapper mapper, UserManager<User> userManager, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _fileService = fileService;
    }


    public async Task<Response<List<GetPostDto>>> GetPostsAsync()
    {
        try
        {
            var posts = await _context.Posts.Select(p => new GetPostDto()
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Title = p.Title,
                    Content = p.Content,
                    PostFiles = p.PostFiles.Select(pf => pf.Name),
                    /*PostViews = p.PostViews,
                    PostLikes = p.PostLikes*/
                }).ToListAsync();
            if (posts.Count == 0)
                return new Response<List<GetPostDto>>(HttpStatusCode.NotFound, "Not exist post");
            return new Response<List<GetPostDto>>(posts);
        }
        catch (Exception ex)
        {
            return new Response<List<GetPostDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetPostDto>> GetPostByIdAsync(int postId)
    {
        try
        {
            var post = await _context.Posts.Select(p => new GetPostDto()
            {
                Id = p.Id,
                UserId = p.UserId,
                Title = p.Title,
                Content = p.Content,
                PostFiles = p.PostFiles.Select(pf => pf.Name),
                /*PostViews = p.PostViews,
                PostLikes = p.PostLikes*/
            }).FirstOrDefaultAsync(p => p.Id == postId);
            if (post == null)
                return new Response<GetPostDto>(HttpStatusCode.NotFound, "Not exist post");
            var mapped = _mapper.Map<GetPostDto>(post);
            return new Response<GetPostDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<GetPostDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<int>> AddPostAsync(AddPostDto model)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return new Response<int>(HttpStatusCode.BadRequest, "not exist user");
            var post = new Post()
            {
                UserId = model.UserId,
                Content = model.Content,
                Title = model.Title,
                DatePublished = DateTime.UtcNow
            };
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            var postFiles = new List<PostFile>();
            foreach (var file in model.Files)
            {
                var fileName = await _fileService.AddFileAsync(file, "Files");
                postFiles.Add(new PostFile()
                {
                    Name = fileName,
                    PostId = post.Id
                });
            }

            await _context.PostFiles.AddRangeAsync(postFiles);
            await _context.SaveChangesAsync();
            return new Response<int>(post.Id);
        }
        catch (Exception ex)
        {
            return new Response<int>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<int>> UpdatePostAsync(UpdatePostDto model)
    {
        try
        {
            var post = await _context.Posts.FindAsync(model.Id);
            if (post == null) return new Response<int>(HttpStatusCode.NotFound, "not found post");
            post.Content = model.Content;
            post.Title = model.Title;
            await _context.SaveChangesAsync();
            return new Response<int>(post.Id);
        }
        catch (Exception ex)
        {
            return new Response<int>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> DeletePostAsync(int postId)
    {
        try
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return new Response<string>(HttpStatusCode.NotFound, "not found post");
            var files = await _context.PostFiles.Where(pf => pf.PostId == post.Id).ToListAsync();
            foreach (var file in files)
                await _fileService.DeleteFileAsync(file.Name, "Files");

            _context.PostFiles.RemoveRange(files);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfully deleted post");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}