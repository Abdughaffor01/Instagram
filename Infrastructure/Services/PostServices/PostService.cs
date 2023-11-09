using AutoMapper;
using Domain.DTOs.PostDTOs;
using Infrastructure.Data;
using Infrastructure.Services.FileServices;

namespace Infrastructure.Services.PostServices;

public class PostService : IPostService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IFileService _fileService;

    public PostService(DataContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IFileService fileService)
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
                DatePublished = p.DatePublished,
                PostFiles = p.PostFiles.Select(pf => pf.Name),
                PostViews = new PostViewDto()
                {
                    View = p.PostViews.View,
                    Users = p.PostViews.Users.Select(u => new PostViewUserDto()
                    {
                        UserId = u.UserId
                    }).ToList()
                },
                PostLikes = new PostLikeDto()
                {
                    Like = p.PostLikes.Like,
                    Users = p.PostLikes.Users.ToList()
                }
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
                DatePublished = p.DatePublished,
                PostFiles = p.PostFiles.Select(pf => pf.Name),
                PostViews = new PostViewDto()
                {
                    View = p.PostViews.View,
                    Users = p.PostViews.Users.Select(u => new PostViewUserDto()
                    {
                        UserId = u.UserId
                    }).ToList()
                },
                PostLikes = new PostLikeDto()
                {
                    Like = p.PostLikes.Like,
                    Users = p.PostLikes.Users.ToList()
                }
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

    public async Task<Response<int>> AddPostAsync(string userId,AddPostDto model)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new Response<int>(HttpStatusCode.BadRequest, "not exist user");
            var post = new Post()
            {
                UserId = userId,
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

            var postLike = new PostLike()
            {
                PostId = post.Id,
                Like = 0
            };
            var postView = new PostView()
            {
                PostId = post.Id,
                View = 0
            };

            await _context.PostLike.AddAsync(postLike);
            await _context.PostViews.AddAsync(postView);

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

    public async Task<Response<bool>> AddViewToPost(string userId,int postViewId)
    {
        try
        {
            var post = await _context.Posts.FindAsync(postViewId);
            var user = await _userManager.FindByIdAsync(userId);
            if (post == null || user == null)
                return new Response<bool>(HttpStatusCode.BadRequest, "No exist user or password");
            var viewUser = new PostViewUser()
            {
                UserId = userId,
                PostViewId = postViewId
            };
            var viewPostUser = await _context.PostViewUsers
                .FirstOrDefaultAsync(pw => pw.UserId == userId && pw.PostViewId == postViewId);
            if (viewPostUser == null)
            {
                await _context.PostViewUsers.AddAsync(viewUser);
                var viewPost = await _context.PostViews.FirstOrDefaultAsync(pl => pl.PostId == postViewId);
                viewPost!.View++;
            }

            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<bool>> AddLikeToPost(string userId,int postLikeId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            var post = await _context.Posts.FindAsync(postLikeId);
            if (user == null || post == null)
                return new Response<bool>(HttpStatusCode.BadRequest, "No exist user or post");
            var likeUser = new PostLikeUser()
            {
                UserId = userId,
                PostLikeId = postLikeId
            };
            var likeUserExist = await _context.PostLikeUsers
                .FirstOrDefaultAsync(pl => pl.PostLikeId == postLikeId && pl.UserId ==userId);
            if (likeUserExist == null)
            {
                await _context.PostLikeUsers.AddAsync(likeUser);
                var likePost = await _context.PostLike.FirstOrDefaultAsync(pl => pl.PostId == postLikeId);
                likePost!.Like++;
                await _context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            else
            {
                _context.PostLikeUsers.Remove(likeUserExist);
                var likePost = await _context.PostLike.FirstOrDefaultAsync(pl => pl.PostId == postLikeId);
                likePost!.Like--;
                await _context.SaveChangesAsync();
                return new Response<bool>(false);
            }
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}