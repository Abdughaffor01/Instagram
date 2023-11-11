using AutoMapper;
using Domain.DTOs.ProfileDTOs;
using Infrastructure.Data;
using Infrastructure.Services.FileServices;

namespace Infrastructure.Services.ProfileServices;

public class ProfileService : IProfileService
{
    private readonly UserManager<User> _userManager;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public ProfileService(DataContext context, UserManager<User> userManager, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<Response<GetProfileDto>> GetProfileByUserIdAsync(string userId)
    {
        try
        {
            var profile = await _context.Profiles.Select(p => new GetProfileDto()
            {
                UserId = p.UserId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                About = p.About,
                Occupation = p.Occupation,
                Gender = p.Gender.ToString()!,
                Photo = p.Photo,
                DateUpdated = p.DateUpdated,
                DOB = p.DOB
            }).FirstOrDefaultAsync(pr => pr.UserId == userId);
            if (profile == null) return new Response<GetProfileDto>(HttpStatusCode.BadRequest, "not found profile");
            return new Response<GetProfileDto>(profile);
        }
        catch (Exception ex)
        {
            return new Response<GetProfileDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<UpdateProfileDto>> UpdateProfileAsync(string userId, UpdateProfileDto model)
    {
        try
        {
            var profile = await _context.Profiles
                .FirstOrDefaultAsync(p => p.UserId == userId);
            if (profile == null) return new Response<UpdateProfileDto>(HttpStatusCode.BadRequest, "No exist profile");
            _mapper.Map(model, profile);
            profile.DateUpdated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new Response<UpdateProfileDto>(_mapper.Map<UpdateProfileDto>(profile));
        }
        catch (Exception ex)
        {
            return new Response<UpdateProfileDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> UpdatePhotoProfileAsync(string userId, IFormFile photo)
    {
        try
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            if (profile == null) return new Response<string>(HttpStatusCode.BadRequest, "not found profile");

            if (profile.Photo != null) await _fileService.DeleteFileAsync(profile.Photo, "Files");
            profile.Photo = await _fileService.AddFileAsync(photo, "Files");
            await _context.SaveChangesAsync();
            return new Response<string>(profile.Photo);
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}