using System.ComponentModel.DataAnnotations;
using Domain.Entities.UserEntities;

namespace Domain.Entities.PostEntities;

public class PostFavorite
{
    [Key]
    [MaxLength(100)]
    public string UserId { get; set; }
    public User User { get; set; }

    public int CountFavorite { get; set; }
    
    public List<FavoriteUser> FavoriteUsers { get; set; }
}
