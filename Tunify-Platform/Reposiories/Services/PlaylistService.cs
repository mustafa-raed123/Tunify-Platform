using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Reposiories.Interface;

namespace Tunify_Platform.Reposiories.Services
{
    public class PlaylistService : IPlaylist
    {
        private readonly TunifyDbContext _tunifyDbContext;
        public PlaylistService(TunifyDbContext tunifyDbContext)
        {
            _tunifyDbContext = tunifyDbContext;
        }

        public async  Task<Playlist> CreatePlaylist(Playlist playlist)
        {
            _tunifyDbContext.playlists.Add(playlist);
            await _tunifyDbContext.SaveChangesAsync();
            return playlist;
        }

        public async Task<Playlist> DeletePlaylist(int Id)
        {
            if (_tunifyDbContext.playlists == null)
            {
                return null;
            }
            var playlist = await _tunifyDbContext.playlists.FindAsync(Id);
            if (playlist == null)
            {
                return null;
            }
            _tunifyDbContext.Entry(playlist).State = EntityState.Deleted;
            await _tunifyDbContext.SaveChangesAsync();
            return playlist;
        }

        public async Task<IEnumerable<Playlist>> GetAllPlayList()
        {
            if (_tunifyDbContext.playlists == null)
            {
                return null;

            }
            var playlists = await _tunifyDbContext.playlists.ToListAsync();
            return playlists;
        }

        public async Task<Playlist> GetPlaylistById(int id)
        {
            var playlist = await _tunifyDbContext.playlists.FindAsync(id);
            if (playlist == null)
            {

                return null;
            }
            return playlist;
        }

        public async Task<Playlist> UpdatePlayList(int Id, Playlist playlist)
        {
            _tunifyDbContext.Entry(playlist).State = EntityState.Modified;
            try
            {
                await _tunifyDbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(Id))
                {
                    return null;
                }
            }

            return playlist;
        }
        private bool PlaylistExists(int id)
        {
            return (_tunifyDbContext.playlists?.Any(e => e.PlaylistId == id)).GetValueOrDefault();
        }
    }
}
