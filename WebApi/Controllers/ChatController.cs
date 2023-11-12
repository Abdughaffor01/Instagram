using Domain.DTOs.ChatDto;
using Infrastructure.Services.ChatServises;

namespace WebApi.Controllers;


[Route("[controller]")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IChatServise _servise;
    public ChatController(IChatServise servise) => _servise = servise;

    [HttpGet("GetChat")]
    public async Task<IActionResult> GetChat()
    {
        var res = await _servise.GetChats();
        return StatusCode(res.StatusCode, res);
    }

    [HttpPost("AddChat")]
    public async Task<IActionResult> AddChat(AddChatDto model)
    {

        var res = await _servise.AddChat(model);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("UpdateChat")]
    public async Task<IActionResult> UpdateChat(AddChatDto model)
    {
        var res = await _servise.UpdateChat(model);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete("DeleteChat")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _servise.Delete(id);
        return StatusCode(res.StatusCode, res);
    }
}