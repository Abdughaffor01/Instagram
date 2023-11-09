using Infrastructure.Services.MessangeServises;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]
public class MessageController : ControllerBase
{
    private readonly IMessageServise _message;

    public MessageController(IMessageServise message)
    {
        _message = message;
    }
}