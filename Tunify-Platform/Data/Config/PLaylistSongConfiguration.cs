using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data.Config
{
    public class PLaylistSongConfiguration : IEntityTypeConfiguration<PlaylistSong>
    {
        public void Configure(EntityTypeBuilder<PlaylistSong> builder)
        {
            builder.ToTable("PlaylistsSongs");
            builder.HasKey(x => x.PlaylistSongId);

            builder.HasOne(x=>x.Playlist)
                .WithMany(x=>x.PlaylistSongs)
                .HasForeignKey(x=>x.PlaylistId);

            builder.HasOne(x => x.Song)
                .WithMany(x => x.PlaylistSongs)
                .HasForeignKey(x => x.SongId);
        }
    }
}
