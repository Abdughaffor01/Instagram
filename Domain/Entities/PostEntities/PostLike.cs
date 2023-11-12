namespace Domain.Entities.PostEntities;

public class PostLike
{
    [Key]
    public int PostId { get; set; }
    public Post Post { get; set; }
    
    public int Like { get; set; }
    
    public IEnumerable<PostLikeUser> Users { get; set; }
}