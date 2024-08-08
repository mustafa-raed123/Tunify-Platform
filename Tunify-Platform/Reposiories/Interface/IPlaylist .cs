using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Reposiories.Interface
{
    public interface IPlaylist
    {
        public Task<IEnumerable<Playlist>> GetAllPlayList();
        public Task<Playlist> UpdatePlayList(int Id, Playlist playlist);
        public Task<Playlist> DeletePlaylist(int Id);
        public Task<Playlist> GetPlaylistById(int id);
        public Task<Playlist> CreatePlaylist(Playlist playlist);
    }
}
