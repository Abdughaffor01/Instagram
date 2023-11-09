using Domain.DTOs.ChatDto;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Services.ChatServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("controller")]
[Authorize]
public class ChatController
{
    private readonly IChatServise _chatServise;

    public ChatController(IChatServise chatServise)
    {
        _chatServise = chatServise;
    }

    [HttpGet("GetChat")]
    public Task<Response<List<GetChatDto>>> GetChat() => _chatServise.GetChats();

    [HttpPost("AddChat")]
    public async Task<Response<GetChatDto>> AddChat(AddChatDto model)
    {
        
       return await _chatServise.AddChat(model);
    }

    [HttpPut("UpdateChat")]
    public async Task<Response<GetChatDto>> UpdateChat(AddChatDto model) => await _chatServise.UpdateChat(model);

    [HttpDelete("DeleteChat")]
    public async Task<Response<GetChatDto>> Delete(int id) =>  await _chatServise.Delete(id);

}