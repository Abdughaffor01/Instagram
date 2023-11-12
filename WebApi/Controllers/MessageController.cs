using Domain.DTOs.MessageDTOs;
using Infrastructure.Services.MessageServises;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly IMessageServise _service;
    public MessageController(IMessageServise servise) => _service = servise;

    [HttpGet("GetMessage")]
    public async Task<IActionResult> GetMessages()
    {
        var res = await _service.GetMessenges();
        return StatusCode(res.StatusCode, res);
    }


    [HttpDelete("DeleteMessage")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        var res = await _service.DeleteMessage(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPost("AddMessage")]
    public async Task<IActionResult> AddMessage(MessageDto model)
    {
        var res = await _service.AddMessange(model);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("UpdateMessage")]
    public async Task<IActionResult> UpdateMessage(MessageDto model)
    {
        var res = await _service.UpdateMessange(model);
        return StatusCode(res.StatusCode, res);
    }
}