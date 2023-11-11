using Domain.Entities;

namespace Domain.DTOs.PostDTOs;

public class PostViewWithUser
{
    public int CountView { get; set; }
    public IEnumerable<User> Users { get; set; } = new List<User>();
}