using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Post
{
    [Key]
    public int Id { get; set; }

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
