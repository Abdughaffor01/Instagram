using Domain.Entities;

namespace Domain.DTOs.PostDTOs;

public class GetPostDto : BasePostDto
{
    public string UserId { get; set; }
    
    public int Id { get; set; }

    public PostViewDto PostViews { get; set; }

    public PostLikeDto PostLikes { get; set; }

    public IEnumerable<string> PostFiles { get; set; } = new List<string>();
}