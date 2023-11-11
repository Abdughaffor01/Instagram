using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Profile
{
    [Key]
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    
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