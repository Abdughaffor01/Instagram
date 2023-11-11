using Domain.DTOs.StoryDTOs;

namespace Infrastructure.Services.StoryServices;

public interface IStoryService
{
    public Task<Response<int>> AddStoryAsync(string userId, AddStoryDto model);
    public Task<Response<string>> DeleteStoryAsync(int id);
    public Task<Response<ICollection<GetStoryDto>>> GetStoriesAsync();
    public Task<Response<ICollection<GetStoryDto>>> GetArchiveStoriesAsync(string userId);
    public Task<Response<GetStoryDto>> GetStoryAsync(int id);
}