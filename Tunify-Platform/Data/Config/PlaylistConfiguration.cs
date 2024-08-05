using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data.Config
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasKey(x => x.PlaylistId);
            builder.Property(x => x.PlaylistName).HasColumnType("varchar").HasMaxLength(100);
            
            builder.HasOne(x=>x.User)
                .WithMany(x=>x.Playlists)
                .HasForeignKey(x=>x.UserId).IsRequired(false);
            builder.HasData(LoadPlaylist());
            
        }

        private List<Playlist> LoadPlaylist()
        {
            return new  List<Playlist>(){
                new Playlist{PlaylistId = 1,PlaylistName = "Rock Classics",CreateDate = new DateTime(2011,4,5)},
                new Playlist{PlaylistId = 2,PlaylistName = "Pop Hits",CreateDate = new DateTime(2013,5,7) , UserId = 2}                
            };
        }
    }
}
