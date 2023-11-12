using Domain.DTOs.MessageDTOs;
using Infrastructure.Services.MessageServises;

namespace WebApi.Controllers;
  [ApiController]
  [Route("controller")]
  [Authorize]
public class MessageController:ControllerBase
{
  private readonly IMessageServise _message;

  public MessageController(IMessageServise message)
  {
    _message = message;
  }

  [HttpGet("GetMessage")]
  public async Task<Response<List<MessageDto>>> GetMessages() => await _message.GetMessenges();

  [HttpDelete("DeleteMessage")]
  public async Task<Response<MessageDto>> DeleteMessage(int id) => await _message.DeleteMessage(id);

  [HttpPost("AddMessage")]
  public async Task<Response<MessageDto>> AddMessage(MessageDto model) => await _message.AddMessange(model);

  [HttpPut("UpdateMessage")]
  public async Task<Response<MessageDto>> UpdateMessage(MessageDto model) => await _message.UpdateMessange(model);

  }