namespace Domain.Entities.StoryEntities;

public class StoryLikeUser
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string UserId { get; set; }
    public User User { get; set; }
    
    public int StoryLikeId { get; set; }
    public StoryLike StoryLike { get; set; }
}
