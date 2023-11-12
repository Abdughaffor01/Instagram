using Domain.DTOs.ChatDto;
using Infrastructure.Services.ChatServises;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("GetChat")]
    public async Task<Response<List<GetChatDto>>> GetChat()
    {
        var userId=User.Claims.FirstOrDefault(x=>x.Type=="sid")!.Value;

    return await _chatService.GetChats(userId);
}

    [HttpGet("GetChatById")]
    public async Task<Response<GetChatDto>> GetChatById(int id)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")!.Value;

       return await _chatService.GetById(id,userId);
    }

    [HttpPost("AddChat")]
    public async Task<Response<GetChatDto>> AddChat(AddChatDto model)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")!.Value;
      
        return await _chatService.AddChat(userId,model);
        
    }
    [HttpDelete("DeleteChat")] 
    public async Task<Response<GetChatDto>> Delete(int id) =>  await _chatService.Delete(id);
    
}