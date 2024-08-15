using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Reposiories.Interface
{
    public interface ISong
    {
        public Task<IEnumerable<Song>> GetAllSongs();
        public Task<Song> UpdateSong(int Id, Song songid);
        public Task<Song> DeleteSong(int Id);
        public Task<Song> GetSongById(int id);
        public Task<Song> CreateSong(Song song);
        public Task<List<Song>> GetSongsByPlaylist(int playlistid);
        public Task<PlaylistSong> AddSongToPlaylist(int songid, int playlistid);
        public Task<Song> AddSongToArtist(int artistId, int songId);
        public Task<List<Song>> GetAllsongsbyanartists(int ArtistId);
    }
}
