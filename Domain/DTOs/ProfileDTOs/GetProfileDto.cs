namespace Domain.DTOs.ProfileDTOs;

public class GetProfileDto
{
    public string UserId { get; set; }
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public string Gender { get; set; }
    
    public DateTime? DOB { get; set; }
    
    public string? Occupation { get; set; }
    
    public string? About { get; set; }

    public string? Photo { get; set; }
    
    public DateTime? DateUpdated { get; set; }
}