using Domain.DTOs.MessangeDto;
using Domain.Response;
using Infrastructure.Services.MessangeServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]
[Authorize]
public class MessageController : ControllerBase
{
  private readonly IMessageServise _message;

  public MessageController(IMessageServise message)
  {
    _message = message;
  }


  [HttpDelete("DeleteMessage")]
  public async Task<Response<MessageDtos>> DeleteMessage(int id) => await _message.DeleteMessage(id);

  [HttpPost("AddMessage")]
  public async Task<Response<MessageDtos>> AddMessage(MessageDtos model)
  {

    var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")!.Value;

    return await _message.AddMessange(userId, model);
  }

} 