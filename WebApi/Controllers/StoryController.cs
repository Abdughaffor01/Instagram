using Domain.DTOs.StoryDTOs;
using Domain.Response;
using Infrastructure.Services.StoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class StoryController : ControllerBase
{
    private readonly IStoryService _service;
    public StoryController(IStoryService service)=>_service = service;


    [HttpPost("AddStoryAsync")]
    public async Task<IActionResult> AddStoryAsync(AddStoryDto model)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.AddStoryAsync(userId,model);
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
    public async Task<Response<bool>> AddLikeToStory(string userId, int storyLikeId)
    {
        var res = await _service.AddLikeToStory(userId, storyLikeId);
        return new Response<bool>(true);
    }
    [HttpPost("AddViewToStory")]
    public async Task<Response<bool>> AddViewToStory(string userId, int storyViewId)
    {
        var res = await _service.AddViewToStory(userId, storyViewId);
        return new Response<bool>(true);
    }

    [HttpGet("GetArchiveStoriesAsync")]
    public async Task<IActionResult> GetArchiveStoriesAsync()
    {
        var userId= User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.GetArchiveStoriesAsync(userId);
        return StatusCode(res.StatusCode, res);
    }
}