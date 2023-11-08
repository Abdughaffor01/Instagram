using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public Profile Profile { get; set; }
    public ExternalAccount ExternalAccount { get; set; }
    public IEnumerable<Post> Post { get; set; }
    public IEnumerable<PostViewUser> PostViewUsers { get; set; }
    public IEnumerable<PostLikeUser> PostLikeUsers  { get; set; }
}