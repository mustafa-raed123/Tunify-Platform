namespace Tunify_Platform.Data.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; } = null!;
        public string? Bio { get; set; }
        public ICollection<Song>? Songs { get; set; } = new List<Song>();

        public ICollection<Album> Albums { get; set; } = new List<Album>();

    }
}
