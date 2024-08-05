namespace Tunify_Platform.Data.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        public ICollection<Song> Songs { get; set; } = new List<Song>();

        public int ArtistId { get; set; }
        public Artist artist { get; set; } = null!;
    }
}
