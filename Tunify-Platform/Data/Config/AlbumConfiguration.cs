using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data.Config
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.AlbumId);
            builder.Property(x => x.AlbumName).HasColumnName("varchar").HasMaxLength(100);

            builder.HasOne(x=>x.artist).WithMany(x=>x.Albums).HasForeignKey(x=>x.ArtistId);

            builder.HasData(LoadAlbum());
            
        }

        private List<Album> LoadAlbum()
        {
            return new List<Album>
            {
                new Album{AlbumId = 1 , AlbumName = "Thriller" ,ArtistId = 1 },
                new Album{AlbumId = 2 , AlbumName = "The Dark Side of the Moon" ,ArtistId = 2 },
                new Album{AlbumId = 3 , AlbumName = "Abbey Road" ,ArtistId = 1 },
            };
        }
    }
}
