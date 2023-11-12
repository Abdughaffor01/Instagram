namespace Domain.Entities.UserEntities;

public class User : IdentityUser
{
    public UserProfile UserProfile { get; set; }

    public Location Location { get; set; }

    public ExternalAccount ExternalAccount { get; set; }
    
    public IEnumerable<Post> Post { get; set; }
    
    public IEnumerable<PostViewUser> PostViewUsers { get; set; }
    
    public IEnumerable<PostLikeUser> PostLikeUsers  { get; set; }

    public IEnumerable<Message> Messages { get; set; }
    
    // public IEnumerable<Chat> Chats { get; set; }

    public PostFavorite PostFavorite { get; set; }

    public IEnumerable<FavoriteUser> FavoriteUsers { get; set; }

    public List<FollowingRelationShip> FollowingRelationShips { get; set; } = null!;
}

