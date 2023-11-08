using Domain.Entities;

namespace Domain.DTOs.PostDTOs;

public class GetPostDto : BasePostDto
{
    public int Id { get; set; }

    public IEnumerable<PostView> PostViews { get; set; } = new List<PostView>();

    public IEnumerable<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public IEnumerable<string> PostFiles { get; set; } = new List<string>();
}