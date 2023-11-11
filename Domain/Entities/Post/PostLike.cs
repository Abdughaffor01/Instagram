using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace Domain.Entities;

public class PostLike
{
    [Key]
    public int PostId { get; set; }
    public Post Post { get; set; }
    
    public int Like { get; set; }
    
    public IEnumerable<PostLikeUser> Users { get; set; }
}