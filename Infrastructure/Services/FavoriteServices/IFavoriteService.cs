namespace Infrastructure.Services.FavoriteServices;

public interface IFavoriteService
{
    public Task<Response<bool>> AddFavoriteToUser(string userId,int postId);
    public Task<Response<List<GetPostDto>>> GetFavoritesByUserId(string userId);
}