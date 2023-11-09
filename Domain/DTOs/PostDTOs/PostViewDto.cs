using Domain.Entities;

namespace Domain.DTOs.PostDTOs;

public class PostViewDto
{
    public int View { get; set; }
    public List<PostViewUserDto> Users { get; set; } = new();
}