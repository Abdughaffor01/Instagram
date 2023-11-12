using Domain.DTOs.ProfileDTOs;
using Infrastructure.Services.ProfileServices;
namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _service;
    public ProfileController(IProfileService service)=> _service = service;


    [HttpPut("UpdateProfileAsync")]
    public async Task<IActionResult> UpdateProfileAsync([FromForm]IFormFile photo,[FromBody]UpdateProfileDto model)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.UpdateProfileAsync(userId,model);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("UpdatePhotoProfileAsync")]
    public async Task<IActionResult> UpdatePhotoProfileAsync(IFormFile photo)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.UpdatePhotoProfileAsync(userId, photo);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("GetProfileByUserIdAsync")]
    public async Task<IActionResult> GetProfileByUserIdAsync()
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.GetProfileByUserIdAsync(userId);
        return StatusCode(res.StatusCode, res);
    }
}