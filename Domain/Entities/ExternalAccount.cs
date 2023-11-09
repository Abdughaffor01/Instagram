using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ExternalAccount
{
    [Key]
    public string UserId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
}