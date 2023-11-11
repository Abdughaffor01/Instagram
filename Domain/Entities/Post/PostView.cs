using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PostView
{
    [Key]
    public int PostId { get; set; }
    public Post Post { get; set; }

    public int View { get; set; }
    public List<PostViewUser> Users { get; set; }
}