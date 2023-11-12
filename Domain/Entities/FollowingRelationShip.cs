using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.UserEntities;

namespace Domain.Entities;

public class FollowingRelationShip
{
    [Key]
    public int Id { get; set; }

    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    
    public string FollowingId { get; set; } = null!;
    [ForeignKey("User")]
    public User Following { get; set; } = null!;
    
    public DateTime DateFollowed { get; set; }
}