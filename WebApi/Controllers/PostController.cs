using Domain.DTOs.PostDTOs;
using Domain.Response;
using Infrastructure.Services.PostServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class PostController : ControllerBase
{
    private readonly IPostService _service;
    public PostController(IPostService service) => _service = service;


    [HttpGet("GetPostsAsync")]
    public async Task<IActionResult> GetPostsAsync()
    {
        var res = await _service.GetPostsAsync();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("GetPostByIdAsync")]
    public async Task<IActionResult> GetPostByIdAsync(int postId)
    {
        var res = await _service.GetPostByIdAsync(postId);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPost("AddPostAsync")]
    public async Task<IActionResult> AddPostAsync(AddPostDto model)
    {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")!.Value;
        
        var res = await _service.AddPostAsync(userId, model);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("UpdatePostAsync")]
    public async Task<IActionResult> UpdatePostAsync(UpdatePostDto model)
    {
        var res =  await _service.UpdatePostAsync(model);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete("DeletePostAsync")]
    public async Task<IActionResult> DeletePostAsync(int postId)
    {
        var res =  await _service.DeletePostAsync(postId);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPost("AddViewToPost")]
    public async Task<Response<bool>> AddViewToPost(int postViewId)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")!.Value;
        return await _service.AddViewToPost(userId,postViewId);
    }

    [HttpPost("AddLikeToPost")]
    public async Task<Response<bool>> AddLikeToPost(int postLikeId)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")!.Value;
        return await _service.AddLikeToPost(userId,postLikeId);
    }
}