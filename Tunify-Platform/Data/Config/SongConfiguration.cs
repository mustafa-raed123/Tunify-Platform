using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Data.Config
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Songs");
            builder.HasKey(x => x.SongId);
            builder.Property(x => x.title)
                .HasColumnType("varchar")
                .HasMaxLength(100);


            builder.HasOne(x => x.Artist)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.ArtistId)
                .IsRequired(false);
            builder.HasOne(x=>x.Album)
                .WithMany(x=>x.Songs)
                .HasForeignKey(x=>x.AlbumId);

            builder.HasData(LoadSongs());
            
        }

        private List<Song> LoadSongs()
        {
            return new List<Song>
            {
                new Song {SongId = 1 , title = "Billie Jean" , ArtistId = 1 , AlbumId = 1 , Genre = "Rock", duration = new TimeSpan(0 , 33 , 55)},
                new Song {SongId = 2 , title = "Bohemian Rhapsody" , ArtistId = 2 , AlbumId = 2 , Genre = "Rock", duration = new TimeSpan(0 , 55 , 55)},

            };
        }
    }
}
