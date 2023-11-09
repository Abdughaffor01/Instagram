using MailKit;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public Profile Profile { get; set; }
   
    public ExternalAccount ExternalAccount { get; set; }
    
    public IEnumerable<Post> Post { get; set; }
    
    public IEnumerable<PostViewUser> PostViewUsers { get; set; }
    
    public IEnumerable<PostLikeUser> PostLikeUsers  { get; set; }

    public IEnumerable<Messange> Messanges { get; set; }
    
    public IEnumerable<Chat> Chats { get; set; }

    public IEnumerable<FavoriteUser> FavoriteUsers { get; set; }
