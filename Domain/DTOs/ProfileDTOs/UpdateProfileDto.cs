using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Domain.DTOs.ProfileDTOs;

public class UpdateProfileDto
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public Gender? Gender { get; set; }
    
    public DateOnly? DOB { get; set; }
    
    public string? Occupation { get; set; }
    
    public string? About { get; set; }
}