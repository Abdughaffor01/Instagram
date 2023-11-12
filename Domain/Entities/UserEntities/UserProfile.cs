namespace Domain.Entities.UserEntities;

public class UserProfile
{
    [Key]
    public string UserId { get; set; }
    public User User { get; set; }
    
    [MaxLength(50)]
    public string? FirstName { get; set; }
    
    [MaxLength(50)]
    public string? LastName { get; set; }

    public Gender? Gender { get; set; }
    
    public DateTime? DOB { get; set; }
    
    [MaxLength(50)]
    public string? Occupation { get; set; }
    
    [MaxLength(500)]
    public string? About { get; set; }

    public string? Photo { get; set; }
    
    public DateTime? DateUpdated { get; set; }
}