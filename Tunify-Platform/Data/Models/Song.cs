namespace Tunify_Platform.Data.Models
{
    public class Song
    {
        public int SongId { get; set; } 
        public string title { get; set; }
        public TimeSpan duration { get; set; }
        public string Genre { get; set; } = null!;

        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();

        public int ArtistId { get; set; } 
        public Artist? Artist { get; set; } = null!;

        
        public int AlbumId { get; set; }
        public Album? Album { get; set; }
    }
}
