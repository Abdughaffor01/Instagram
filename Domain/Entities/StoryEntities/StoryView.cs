namespace Domain.Entities.StoryEntities;

public class StoryView
{
    [Key]
    public int StoryId { get; set; }
    public Story Story { get; set; }

    public int View { get; set; }
    public IEnumerable<StoryViewUser> Users { get; set; }
}
