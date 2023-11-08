using Domain.DTOs.PostDTOs;

namespace Infrastructure.Services.PostServices;

public interface IPostService
{
    public Task<Response<List<GetPostDto>>> GetPostsAsync();
    public Task<Response<GetPostDto>> GetPostByIdAsync(int postId);
    public Task<Response<int>> AddPostAsync(AddPostDto model);
    public Task<Response<int>> UpdatePostAsync(UpdatePostDto model);
    public Task<Response<string>> DeletePostAsync(int postId);
}