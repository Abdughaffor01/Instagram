using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public Profile Profile { get; set; }

    public Location Location { get; set; }

    public ExternalAccount ExternalAccount { get; set; }
    
    public IEnumerable<Post> Post { get; set; }
    
    public IEnumerable<PostViewUser> PostViewUsers { get; set; }
    
    public IEnumerable<PostLikeUser> PostLikeUsers  { get; set; }

    public IEnumerable<Message> Messages { get; set; }
    
    // public IEnumerable<Chat> Chats { get; set; }

    public IEnumerable<FavoriteUser> FavoriteUsers { get; set; }

}