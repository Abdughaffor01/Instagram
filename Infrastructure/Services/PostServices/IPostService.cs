using Domain.DTOs.PostDTOs;

namespace Infrastructure.Services.PostServices;

public interface IPostService
{
    public Task<Response<List<GetPostDto>>> GetPostsAsync();
    public Task<Response<GetPostDto>> GetPostByIdAsync(int postId);
    public Task<Response<int>> AddPostAsync(string userId,AddPostDto model);
    public Task<Response<int>> UpdatePostAsync(UpdatePostDto model);
    public Task<Response<string>> DeletePostAsync(int postId);
    public Task<Response<bool>> AddViewToPost(string userId,int postViewId);
    public Task<Response<bool>> AddLikeToPost(string userId,int postLikeId);
}