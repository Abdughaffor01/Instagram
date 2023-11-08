using Microsoft.VisualBasic.CompilerServices;

namespace Domain.Entities;

public class PostLike
{
    public int Id { get; set; }
    public int Like { get; set; }
    public IEnumerable<PostLikeUser> PostLikeUser { get; set; }
}