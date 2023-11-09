using Domain.DTOs.PostDTOs;
using Domain.DTOs.StoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.StoryServices
{
    public interface IStoryService
    {
        public Task<Response<int>> AddStoryAsync(AddStoryDTO model);
        public Task<Response<string>> DeleteStoryAsync(int id);
        public Task<Response<ICollection<GetStoryDTO>>> GetStoriesAsync();
        public Task<Response<GetStoryDTO>> GetStoryAsync(int id);
    }
}
