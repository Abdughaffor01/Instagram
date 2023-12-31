using Domain.DTOs.StoryDTOs;
using Infrastructure.Services.StoryServices;

namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class StoryController : ControllerBase
{
    private readonly IStoryService _service;
    public StoryController(IStoryService service) => _service = service;


    [HttpPost("AddStoryAsync")]
    public async Task<IActionResult> AddStoryAsync(AddStoryDto model)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.AddStoryAsync(userId, model);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete("DeleteStoryAsync")]
    public async Task<IActionResult> DeleteStoryAsync(int id)
    {
        var res = await _service.DeleteStoryAsync(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("GetStoriesAsync")]
    public async Task<IActionResult> GetStoriesAsync()
    {
        var res = await _service.GetStoriesAsync();
        return StatusCode(res.StatusCode, res);
    }

    [HttpPost("AddLikeToStory")]
    public async Task<IActionResult> AddLikeToStory(int storyLikeId)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.AddLikeToStory(userId, storyLikeId);
        return StatusCode(res.StatusCode,res);
    }

    [HttpPost("AddViewToStory")]
    public async Task<IActionResult> AddViewToStory(int storyViewId)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.AddViewToStory(userId, storyViewId);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("GetArchiveStoriesAsync")]
    public async Task<IActionResult> GetArchiveStoriesAsync()
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.GetArchiveStoriesAsync(userId);
        return StatusCode(res.StatusCode, res);
    }
}