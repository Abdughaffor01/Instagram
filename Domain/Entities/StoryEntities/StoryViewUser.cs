using System.ComponentModel.DataAnnotations;
using Domain.Entities.UserEntities;

namespace Domain.Entities.StoryEntities;

public class StoryViewUser
{
    public int Id { get; set; }
    [MaxLength(100)]
    
    public string UserId { get; set; }
    public User User { get; set; }
    
    public int StoryViewId { get; set; }
    public StoryView StoryView { get; set; }
}
