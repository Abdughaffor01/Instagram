using Domain.DTOs.FavoriteDTOs;
using Infrastructure.Data;

namespace Infrastructure.Services.FavoriteServices;

public class FavoriteService : IFavoriteService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly DataContext _context;

    public FavoriteService(UserManager<ApplicationUser> userManager, DataContext context)
    {
        _userManager = userManager;
        _context = context;
    }


    public async Task<Response<bool>> AddFavoriteToUser(string userId,int postId)
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

    public async Task<Response<List<GetFavoriteDto>>> GetFavoritesByUserId(string userId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new Response<List<GetFavoriteDto>>(HttpStatusCode.BadRequest, "No exist user");
            var favorites = await _context.FavoriteUsers
                .Where(fu => fu.UserId == userId).Select(fu => new GetFavoriteDto()
                {
                    PostId = fu.PostId,
                    FileName = fu.Post.PostFiles.Select(u => u.Name).FirstOrDefault()!
                }).ToListAsync();
            return new Response<List<GetFavoriteDto>>(favorites);
        }
        catch (Exception ex)
        {
            return new Response<List<GetFavoriteDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}