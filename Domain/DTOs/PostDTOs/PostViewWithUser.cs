using Domain.Entities;

namespace Domain.DTOs.PostDTOs;

public class PostViewWithUser
{
    public int CountView { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}