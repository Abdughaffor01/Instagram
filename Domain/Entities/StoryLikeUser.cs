namespace Domain.Entities;

public class StoryLikeUser
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    
    public int StoryLikeId { get; set; }
    public StoryLike StoryLike { get; set; }
}
