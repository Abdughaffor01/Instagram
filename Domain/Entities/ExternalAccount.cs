using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ExternalAccount
{
    [Key]
    public string UserId { get; set; } = null!;

    [MaxLength(100)]
    public string Name { get; set; }

    public User User { get; set; }
}