using Microsoft.EntityFrameworkCore;

namespace GameBattle
{
    public class LessonContext : DbContext
    {
        public LessonContext(DbContextOptions<LessonContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } 
        public DbSet<Clan> Clans { get; set; } 
        public DbSet<FriendRequest> FriendsRequests { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }
        public DbSet<ClanRequest> ClansRequests { get; set; }
    }
}