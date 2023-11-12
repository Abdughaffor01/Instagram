using System.ComponentModel.DataAnnotations;
using Domain.Entities.UserEntities;

namespace Domain.Entities.PostEntities;

public class Post
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string UserId { get; set; }

    public User User { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public DateTime DatePublished { get; set; }

    public PostView PostViews { get; set; }
    
    public PostLike PostLikes { get; set; }

    public IEnumerable<PostFile> PostFiles { get; set; }
    
    public IEnumerable<FavoriteUser> FavoriteUsers { get; set; }
}
