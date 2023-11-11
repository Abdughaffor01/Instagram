using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class StoryViewUser
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    
    public int StoryViewId { get; set; }
    public StoryView StoryView { get; set; }
}
