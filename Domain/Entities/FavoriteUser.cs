namespace Domain.Entities;

public class FavoriteUser
{
    public int Id { get; set; }
    public string UserId { get; set; }
    
    public User User { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
}