using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data.Config
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.ArtistId);
            builder.Property(x => x.ArtistName).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Bio).HasColumnType("text");
            builder.HasData(LoadArtists());
        }

        private List<Artist> LoadArtists()
        {
            return new List<Artist> {

             new Artist { ArtistId = 1, ArtistName = "Michael Jackson" , Bio =" good" },
             new Artist { ArtistId = 2, ArtistName = "Pink Floyd" , Bio =" good" },
             new Artist { ArtistId = 3, ArtistName = "The Beatles" , Bio =" good" },

            };
        }
    }
}
