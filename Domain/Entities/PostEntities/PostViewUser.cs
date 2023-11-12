namespace Domain.Entities.PostEntities;

public class PostViewUser
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string UserId { get; set; }
    public User User { get; set; }
    
    public int PostViewId { get; set; }
    public PostView PostView { get; set; }
}
