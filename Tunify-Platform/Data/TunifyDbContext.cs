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
            modelBuilder.Entity<PlaylistSong>().HasData(
                   new PlaylistSong { PlaylistSongId = 1, PlaylistId = 1, SongId = 1 },
                   new PlaylistSong { PlaylistSongId = 2, PlaylistId = 2, SongId = 3 },
                   new PlaylistSong { PlaylistSongId = 3, PlaylistId = 3, SongId = 2 }
                );

        }
    }
}
