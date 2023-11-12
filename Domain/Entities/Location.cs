using System.ComponentModel.DataAnnotations;
using Domain.Entities.UserEntities;

namespace Domain.Entities;

public class Location
{
    [Key]
    public string UserId { get; set; }
    public User User { get; set; }
    
    [MaxLength(50)]
    public string? City { get; set; }

    [MaxLength(50)]
    public string? State { get; set; }
    
    [MaxLength(50)]
    public string? ZipCode { get; set; }
    
    [MaxLength(50)]
    public string? Country { get; set; }
}
