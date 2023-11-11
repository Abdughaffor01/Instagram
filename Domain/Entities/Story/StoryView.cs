using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class StoryView
{
    [Key]
    public int StoryId { get; set; }
    public Story Story { get; set; }

    public int View { get; set; }
    public List<StoryViewUser> Users { get; set; }
}
