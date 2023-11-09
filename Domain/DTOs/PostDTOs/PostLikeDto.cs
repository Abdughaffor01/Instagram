using Domain.Entities;

namespace Domain.DTOs.PostDTOs;

public class PostLikeDto
{
    public int Like { get; set; }
    public List<PostLikeUser> Users { get; set; } = new();
}