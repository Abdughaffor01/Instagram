using System.Net;
using Domain.DTOs.StoryDTOs;
using Domain.Response;
using Infrastructure.Services.StoryServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoryController : ControllerBase
{
    private readonly IStoryService _storyService;

    public StoryController(IStoryService storyService)
    {
        _storyService = storyService;
    }

    [HttpPost("Add-story")]
    public async Task<Response<int>> AddStoryAsync([FromForm]AddStoryDTO model)
    {
        await _storyService.AddStoryAsync(model);
        return new Response<int>(HttpStatusCode.OK, "Story added!");
    }

    [HttpDelete("Delete-story")]
    public async Task<Response<string>> DeleteStoryAsync(int id)
    {
        await _storyService.DeleteStoryAsync(id);
        return new Response<string>(HttpStatusCode.OK, "Story deleted!");
    }
}
