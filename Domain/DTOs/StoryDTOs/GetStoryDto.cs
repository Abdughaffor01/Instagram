namespace Domain.DTOs.StoryDTOs;

public class GetStoryDto
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; }
    public int? PostId { get; set; }
}