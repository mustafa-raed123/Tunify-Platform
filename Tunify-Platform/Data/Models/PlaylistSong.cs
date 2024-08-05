namespace Tunify_Platform.Data.Models
{
    public class PlaylistSong
    {
        public int PlaylistSongId { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
