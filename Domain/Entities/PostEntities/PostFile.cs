namespace Domain.Entities.PostEntities;

public class PostFile
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
}