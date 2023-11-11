using Domain.Enums;

namespace Domain.DTOs.ProfileDTOs;

public class UpdateProfileDto
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public Gender? Gender { get; set; }
    
    public DateTime? DOB { get; set; }
    
    public string? Occupation { get; set; }
    
    public string? About { get; set; }
}