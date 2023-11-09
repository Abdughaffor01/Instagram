using Infrastructure.Services.FavoriteServices;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService _service;
    public FavoriteController(IFavoriteService service)=>_service = service;

    [HttpPost("AddFavoriteToUser")]
    public async Task<IActionResult> AddFavoriteToUser(int postId)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")!.Value;
        var res = await _service.AddFavoriteToUser(userId, postId);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("GetFavoritesByUserId")]
    public async Task<IActionResult> GetFavoritesByUserId()
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.GetFavoritesByUserId(userId);
        return StatusCode(res.StatusCode, res);
    }
}