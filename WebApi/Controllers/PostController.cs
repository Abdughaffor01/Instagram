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

    public PostController(IPostService service)=>_service = service;


    [HttpGet("GetPostsAsync")]
    public async Task<Response<List<GetPostDto>>> GetPostsAsync()
    {
        return await _service.GetPostsAsync();
    }

    [HttpGet("GetPostByIdAsync")]
    public async Task<Response<GetPostDto>> GetPostByIdAsync(int postId)
    {
        return await _service.GetPostByIdAsync(postId);
    }

    [HttpPost("AddPostAsync")]
    public async Task<Response<int>> AddPostAsync(AddPostDto model)
    {
        return await _service.AddPostAsync(model);
    }

    [HttpPut("UpdatePostAsync")]
    public async Task<Response<int>> UpdatePostAsync(UpdatePostDto model)
    {
        return await _service.UpdatePostAsync(model);
    }

    [HttpDelete("DeletePostAsync")]
    public async Task<Response<string>> DeletePostAsync(int postId)
    {
        return await _service.DeletePostAsync(postId);
    }
}