using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Location
{
    [Key]
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    
    [MaxLength(50)]
    public string? City { get; set; }

    [MaxLength(50)]
    public string? State { get; set; }
    
    [MaxLength(50)]
    public string? ZipCode { get; set; }
    
    [MaxLength(50)]
    public string? Country { get; set; }
}