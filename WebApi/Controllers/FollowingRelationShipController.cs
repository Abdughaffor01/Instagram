using Domain.DTOs.FollowingRelationShipDTOs;
using Infrastructure.Services.FollowingRelationShipServices;

namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class FollowingRelationShipController: BaseController
{
    private readonly IFollowingRelationShipService _service;
    public FollowingRelationShipController(IFollowingRelationShipService service)=>_service = service;

    [HttpGet("GetFollowingRelationShips")]
    public async Task<IActionResult> GetFollowingRelationShips(string userId)
    {
        var result = await _service.GetFollowingRelationShip(userId);
        return StatusCode(result.StatusCode, result);
    }

    /*[HttpGet("get-FollowingRelationShip-by-id")]
    public async Task<IActionResult> GetFollowingRelationShipById(int id)
    {
        var result = await _service.GetFollowingRelationShipById(id);
        return StatusCode(result.StatusCode, result);
    }*/

    [HttpPost("AddFollowingRelationShip")]
    public async Task<IActionResult> AddFollowingRelationShip(string followingUserId)
    {
        if (ModelState.IsValid)
        {
            var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
            var result = await _service.AddFollowingRelationShip(followingUserId, userId);
            return StatusCode(result.StatusCode, result);
        }

        var response = new Response<FollowingRelationShipDto>(HttpStatusCode.BadRequest, ModelStateErrors());
        return StatusCode(response.StatusCode, response);
    }
}