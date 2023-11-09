using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.StoryDTOs;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Services.FileServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Services.StoryServices
{
    public class StoryService : IStoryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;

        public StoryService(DataContext dataContext, IMapper mapper, UserManager<User> userManager, IFileService fileService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
        }
        public async Task<Response<int>> AddStoryAsync(AddStoryDTO model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                var post=await _dataContext.Posts.FindAsync(model.PostId);
                if (user == null) return new Response<int>(HttpStatusCode.BadRequest, "User or post doesn`t exist!");
                if (model.PostId == null && model.File == null) return new Response<int>(HttpStatusCode.BadRequest, "Something is wrong!");

                var fileName=string.Empty;
                var postId = 0;
                if(model.PostId!=null) postId = (int)model.PostId;
                if(model.File!=null) fileName = await _fileService.AddFileAsync(model.File!, "Files");

                var story = new Story()
                {
                    UserId = model.UserId,
                    PostId = postId,
                    CreatedAt = DateTime.UtcNow,
                    FileName=fileName,
                    StatusStory=StatusStory.Active
                };
                await _dataContext.Stories.AddAsync(story);
                await _dataContext.SaveChangesAsync();
                return new Response<int>(story.Id);
            }
            catch (Exception ex)
            {
                return new Response<int>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<string>> DeleteStoryAsync(int id)
        {
            try
            {
                var story = await _dataContext.Stories.FindAsync(id);
                if (story == null) return new Response<string>(HttpStatusCode.NotFound, "Data not found!");
                if(story.FileName!=null)  await _fileService.DeleteFileAsync(story.FileName, "Files");
                _dataContext.Stories.Remove(story);
                await _dataContext.SaveChangesAsync();
                return new Response<string>(HttpStatusCode.OK, "Story deleted!");

            }
            catch (Exception ex)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<ICollection<GetStoryDTO>>> GetStoriesAsync()
        {
            var stories = await _dataContext.Stories.Select(s => new GetStoryDTO()
            {
                UserId = s.UserId,
                PostId = s.PostId,
                CreatedAt = s.CreatedAt,
                FileName = s.FileName
            }).ToListAsync();
            return new Response<ICollection<GetStoryDTO>>(stories);

        }

        public async Task<Response<GetStoryDTO>> GetStoryAsync(int id)
        {
            var story = await _dataContext.Stories.FindAsync(id);
            if (story == null) return new Response<GetStoryDTO>(HttpStatusCode.NotFound, "Data not found!");
            var mapped = new GetStoryDTO()
            {
                UserId = story.UserId,
                PostId = story.PostId,
                CreatedAt = story.CreatedAt,
                FileName = story.FileName
            };
            return new Response<GetStoryDTO>(mapped);
        }
    }
}
