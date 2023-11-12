namespace Domain.Entities.StoryEntities;

public class StoryLike
{
    [Key]
    public int StoryId { get; set; }
    public StoryEntities.Story Story { get; set; }
    
    public int Like { get; set; }
    
    public IEnumerable<StoryLikeUser> Users { get; set; }
}
