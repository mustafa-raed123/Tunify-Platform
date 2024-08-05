using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Subscription> subsciptions {  get; set; } 
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> albums { get; set; }
        public DbSet<Artist> artists { get; set; }
        public DbSet<Playlist> playlists { get; set; }
        public DbSet<PlaylistSong> playlistSongs { get; set; }

        public TunifyDbContext(DbContextOptions options ) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TunifyDbContext).Assembly);
        }
    }
}
