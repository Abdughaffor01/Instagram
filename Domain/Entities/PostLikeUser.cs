namespace Domain.Entities;

public class PostLikeUser
{
    public int Id { get; set; }
  
    public string UserId { get; set; }
    public User User { get; set; }
    
    public int PostLikeId { get; set; }
    public PostLike PostLike { get; set; }
}
