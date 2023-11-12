namespace Domain.Entities.StoryEntities;

public class Story
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string? FileName { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public StatusStory StatusStory { get; set; }
    [MaxLength(100)]
    public string UserId { get; set; }
    public User User { get; set; }

    public int? PostId { get; set; }
    public Post? Post { get; set; }

    public StoryLike StoryLike { get; set; }
    public StoryView StoryView { get; set; }
}