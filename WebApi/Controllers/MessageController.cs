using Infrastructure.Services.MessangeServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
  public async Task<Response<List<MessageDtos>>> GetMessages() => await _message.GetMessenges();

  [HttpDelete("DeleteMessage")]
  public async Task<Response<MessageDtos>> DeleteMessage(int id) => await _message.DeleteMessage(id);

  [HttpPost("AddMessage")]
  public async Task<Response<MessageDtos>> AddMessage(MessageDtos model) => await _message.AddMessange(model);

  [HttpPut("UpdateMessage")]
  public async Task<Response<MessageDtos>> UpdateMessage(MessageDtos model) => await _message.UpdateMessange(model);

  }