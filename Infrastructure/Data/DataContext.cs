namespace Infrastructure.Data;

public class DataContext : IdentityDbContext<User>
{

    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<Profile> Profiles  { get; set; }

    public DbSet<Post> Posts  { get; set; }
    
    public DbSet<PostViewUser> PostViewUsers { get; set; }
    
    public DbSet<PostView> PostViews { get; set; }

    public PostLikeUser PostLikeUser { get; set; }

    public DbSet<PostLike> PostLike { get; set; }

    public DbSet<PostLikeUser> PostLikeUsers { get; set; }
    
    public DbSet<Location> Locations { get; set; }
    
    public DbSet<ExternalAccount> ExternalAccounts { get; set; }
    
    public DbSet<Chat> Chats { get; set; }
    
    public DbSet<Messange> Messanges { get; set; } 
    
    public DbSet<PostFile> PostFiles { get; set; }
    
    public DbSet<Story> Stories { get; set; }
    
    public DbSet<FavoriteUser> FavoriteUsers { get; set; }
    
    public DbSet<PostFavorite> Favorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<PostViewUser>()
            .HasKey(sg => new { sg.UserId, sg.PostViewId });
         modelBuilder.Entity<PostLikeUser>()
            .HasKey(sg => new { sg.UserId, sg.PostLikeId });

         modelBuilder.Entity<FavoriteUser>()
             .HasKey(sg => new { sg.UserId, sg.PostId });


        base.OnModelCreating(modelBuilder);  
    }
}