namespace Tunify_Platform.Data.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
        
    }
}
