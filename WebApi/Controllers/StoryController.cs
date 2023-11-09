
using Domain.DTOs.StoryDTOs;
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
}