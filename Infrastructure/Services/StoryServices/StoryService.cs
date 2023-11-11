using Domain.DTOs.StoryDTOs;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Services.FileServices;

namespace Infrastructure.Services.StoryServices
{
    public class StoryService : IStoryService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;

        public StoryService(DataContext dataContext, UserManager<User> userManager,
            IFileService fileService)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _fileService = fileService;
        }

        public async Task<Response<int>> AddStoryAsync(string userId, AddStoryDto model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var post = await _dataContext.Posts.FindAsync(model.PostId);
                if (model.PostId == null && model.File == null)
                    return new Response<int>(HttpStatusCode.BadRequest, "Something is wrong!");
                if (model.PostId == null) return new Response<int>(HttpStatusCode.BadRequest, "Post not found!");
                var fileName = string.Empty;
                int? postId = null;
                if (model.PostId != null) postId = model.PostId;
                if (model.File != null) fileName = await _fileService.AddFileAsync(model.File!, "Files");

                var story = new Story()
                {
                    UserId = userId,
                    PostId = postId,
                    CreatedAt = DateTime.UtcNow,
                    FileName = fileName,
                    StatusStory = StatusStory.Active
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
                if (story.FileName != "") await _fileService.DeleteFileAsync(story.FileName, "Files");
                _dataContext.Stories.Remove(story);
                await _dataContext.SaveChangesAsync();
                return new Response<string>(HttpStatusCode.OK, "Story deleted!");
            }
            catch (Exception ex)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<ICollection<GetStoryDto>>> GetStoriesAsync()
        {
            /*var storiesStatus =
                await _dataContext.Stories.Where(s => s.StatusStory == StatusStory.Active).ToListAsync();
            foreach (var story in storiesStatus)
            {
                if (story.CreatedAt.AddMinutes(1) <= DateTime.UtcNow)
                {
                    story.StatusStory = StatusStory.Archive;
                }
            }*/
            await _dataContext.SaveChangesAsync();


            var stories = await _dataContext.Stories.Select(s => new GetStoryDto()
            {
                UserId = s.UserId,
                PostId = s.PostId,
                CreatedAt = s.CreatedAt,
                FileName = s.FileName
            }).ToListAsync();

            return new Response<ICollection<GetStoryDto>>(stories);
        }

        public async Task<Response<GetStoryDto>> GetStoryAsync(int id)
        {
            var story = await _dataContext.Stories.FindAsync(id);
            if (story == null) return new Response<GetStoryDto>(HttpStatusCode.NotFound, "Data not found!");
            var mapped = new GetStoryDto()
            {
                UserId = story.UserId,
                PostId = story.PostId,
                CreatedAt = story.CreatedAt,
                FileName = story.FileName
            };
            return new Response<GetStoryDto>(mapped);
        }

        public async Task<Response<bool>> AddLikeToStory(string userId, int storyLikeId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var story = await _dataContext.Stories.FindAsync(storyLikeId);
                if (user == null || story == null) return new Response<bool>(HttpStatusCode.BadRequest, "User or Story doesn't exist!");
                var userLike = new StoryLikeUser()
                {
                    UserId = userId,
                    StoryLikeId = storyLikeId
                };

                var userLikeExist = _dataContext.StoryLikeUsers.FirstOrDefaultAsync(sl => sl.StoryLikeId == storyLikeId && sl.UserId == userId);
                if (userLikeExist == null)
                {
                    await _dataContext.StoryLikeUsers.AddAsync(userLike);
                    var storyLike = await _dataContext.StoryLikes.FirstOrDefaultAsync(sl => sl.StoryId == storyLikeId);
                    storyLike!.Like++;
                    await _dataContext.SaveChangesAsync();
                    return new Response<bool>(true);
                }
                else
                {
                    // _dataContext.StoryLikeUsers.Remove(userLikeExist);
                    var storyLike = await _dataContext.StoryLikes.FirstOrDefaultAsync(sl=> sl.StoryId == storyLikeId);
                    storyLike!.Like--;
                    await _dataContext.SaveChangesAsync();
                    return new Response<bool>(false);
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response<bool>> AddViewToStory(string userId, int storyViewId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var story = await _dataContext.Stories.FindAsync(storyViewId);
                if (user == null || story == null) return new Response<bool>(HttpStatusCode.BadRequest,"User or Story doesn't exist!");
                var viewUser = new StoryViewUser()
                {
                    UserId = userId,
                    StoryViewId = storyViewId
                };
                var viewStoryUser = _dataContext.StoryLikeUsers.FirstOrDefaultAsync(sv=> sv.UserId == userId && sv.StoryLikeId == storyViewId);
                if (viewStoryUser == null)
                {
                    await _dataContext.StoryViewUsers.AddAsync(viewUser);
                    var viewStory = await _dataContext.StoryViews.FirstOrDefaultAsync(sv=> sv.StoryId == storyViewId);
                    viewStory!.View++;
                }

                await _dataContext.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}