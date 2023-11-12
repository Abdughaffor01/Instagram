namespace Infrastructure.Services.FavoriteServices;

public class FavoriteService : IFavoriteService
{
    private readonly UserManager<User> _userManager;
    private readonly DataContext _context;

    public FavoriteService(UserManager<User> userManager, DataContext context)
    {
        _userManager = userManager;
        _context = context;
    }


    public async Task<Response<bool>> AddFavoriteToUser(string userId, int postId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            var post = await _context.Posts.FindAsync(postId);
            if (user == null || post == null)
                return new Response<bool>(HttpStatusCode.NotFound, "No exist user or post");
            var favoriteUser = new FavoriteUser()
            {
                PostId = postId,
                UserId = userId
            };
            var favoriteUserExist = await _context.FavoriteUsers
                .FirstOrDefaultAsync(fu => fu.UserId == userId && fu.PostId == postId);
            if (favoriteUserExist == null)
            {
                await _context.FavoriteUsers.AddAsync(favoriteUser);
                await _context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            else
            {
                _context.FavoriteUsers.Remove(favoriteUserExist);
                await _context.SaveChangesAsync();
                return new Response<bool>(false);
            }
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<List<GetPostDto>>> GetFavoritesByUserId(string userId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new Response<List<GetPostDto>>(HttpStatusCode.BadRequest, "No exist user");
            var favorites = await _context.FavoriteUsers.Where(fu => fu.UserId == userId)
                .Select(fu => new GetPostDto()
                {
                    Id = fu.Post.Id,
                    UserId = fu.UserId,
                    DatePublished = fu.Post.DatePublished,
                    Title = fu.Post.Title,
                    Content = fu.Post.Content,
                    PostFiles = fu.Post.PostFiles.Select(pf => pf.Name).ToList(),
                    PostViews = new PostViewDto()
                    {
                        View = fu.Post.PostViews.View,
                        Users = fu.Post.PostViews.Users.Select(u => new PostViewUserDto()
                        {
                            UserId = u.User.Id
                        }).ToList()
                    },
                    PostLikes = new PostLikeDto()
                    {
                        Like = fu.Post.PostLikes.Like,
                        Users = fu.Post.PostLikes.Users.Select(u => new PostLikeUserDto()
                        {
                            UserId = u.User.Id
                        }).ToList()
                    },
                }).ToListAsync();
            if (favorites.Count == 0) return new Response<List<GetPostDto>>(HttpStatusCode.NotFound, "No favorites");
            return new Response<List<GetPostDto>>(favorites);
        }
        catch (Exception ex)
        {
            return new Response<List<GetPostDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}