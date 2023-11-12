namespace Infrastructure.Services.ProfileServices;

public interface IProfileService
{
    public Task<Response<GetProfileDto>> GetProfileByUserIdAsync(string userId);
    public Task<Response<GetProfileDto>> GetProfileByIdAsync(string userId);
    public Task<Response<UpdateProfileDto>> UpdateProfileAsync(string userId,UpdateProfileDto model);
    public Task<Response<string>> UpdatePhotoProfileAsync(string userId,IFormFile photo);
}