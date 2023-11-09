using Domain.DTOs.ProfileDTOs;

namespace Infrastructure.Services.ProfileServices;

public interface IProfileService
{
    public Task<Response<UpdateProfileDto>> UpdateProfileAsync(string userId,UpdateProfileDto model);
    public Task<Response<string>> UpdatePhotoAsync(string userId,IFormFile photo);
}