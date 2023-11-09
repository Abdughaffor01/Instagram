using Domain.DTOs.ProfileDTOs;
using Infrastructure.Services.ProfileServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _service;
    public ProfileController(IProfileService service)=> _service = service;


    [HttpPut("UpdateProfileAsync")]
    public async Task<IActionResult> UpdateProfileAsync([FromBody]UpdateProfileDto model)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.UpdateProfileAsync(userId, model);
        return StatusCode(res.StatusCode, res);
    }
    
    [HttpPut("UpdateProfileAsync")]
    public async Task<IActionResult> UpdatePhotoAsync(IFormFile photo)
    {
        var userId = User.Claims.FirstOrDefault(u => u.Type == "sid")!.Value;
        var res = await _service.UpdatePhotoAsync(userId, photo);
        return StatusCode(res.StatusCode, res);
    }
}