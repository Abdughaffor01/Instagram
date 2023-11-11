using Domain.Entities;

namespace Domain.DTOs.PostDTOs;

public class PostLikeDto
{
    public int Like { get; set; }
    public List<PostLikeUserDto> Users { get; set; } = new();
}