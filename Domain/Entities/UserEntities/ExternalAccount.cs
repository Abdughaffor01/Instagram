using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.UserEntities;

public class ExternalAccount
{
    [Key]
    [MaxLength(100)]
    public string UserId { get; set; } = null!;

    [MaxLength(100)]
    public string Name { get; set; }

    public User User { get; set; }
}


