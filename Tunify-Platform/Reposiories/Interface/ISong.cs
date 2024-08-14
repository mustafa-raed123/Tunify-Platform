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
        public Task<List<Playlist>> GetPlaylistForSong(int song);
    }
}
