using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class StoryLike
{
    [Key]
    public int StoryId { get; set; }
    public Story Story { get; set; }
    
    public int Like { get; set; }
    
    public IEnumerable<StoryLikeUser> Users { get; set; }
}
