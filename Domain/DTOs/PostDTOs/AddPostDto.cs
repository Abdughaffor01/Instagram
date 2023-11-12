namespace Domain.DTOs.PostDTOs;

public class AddPostDto : BasePostDto
{
    public IEnumerable<IFormFile> Files { get; set; }
}