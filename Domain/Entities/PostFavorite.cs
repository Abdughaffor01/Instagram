using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PostFavorite
{
    [Key]
    public string UserId { get; set; }
    public User User { get; set; }

    public int CountFavorite { get; set; }
    
    public List<FavoriteUser> FavoriteUsers { get; set; }
}