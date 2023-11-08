using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PostView
{
    [Key]
    public int Id { get; set; }

    public int View { get; set; }

    public PostViewUser Users { get; set; }
}