using Microsoft.AspNetCore.Http;

namespace Domain.DTOs.StoryDTOs;

public class AddStoryDto
{
    public int? PostId { get; set; }
    public IFormFile? File { get; set; }
}