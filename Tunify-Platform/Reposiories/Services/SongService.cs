using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Reposiories.Interface;

namespace Tunify_Platform.Reposiories.Services
{
    public class SongService : ISong
    {
        private readonly TunifyDbContext _tunifyDbContext;
        public SongService(TunifyDbContext tunifyDbContext)
        {
            _tunifyDbContext = tunifyDbContext;
        }
        public async Task<Song> CreateSong(Song song)
        {
            _tunifyDbContext.Songs.Add(song);
            await _tunifyDbContext.SaveChangesAsync();
            return song;
        }

        public async Task<Song> DeleteSong(int Id)
        {
            if (_tunifyDbContext.users == null)
            {
                return null;
            }
            var song = await _tunifyDbContext.Songs.FirstAsync(u => u.SongId == Id);
            if (song == null)
            {
                return null;
            }
            _tunifyDbContext.Entry(song).State = EntityState.Deleted;
            await _tunifyDbContext.SaveChangesAsync();
            return song;
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            if (_tunifyDbContext.Songs == null)
            {
                return null;

            }
            var songs = await _tunifyDbContext.Songs.ToListAsync();
            return songs;
        }

        public async Task<Song> GetSongById(int id)
        {
            var song = await _tunifyDbContext.Songs.FindAsync(id);
            if (song == null)
            {

                return null;
            }
            return song;
        }

        public async Task<Song> UpdateSong(int Id, Song song)
        {
            _tunifyDbContext.Entry(song).State = EntityState.Modified;
            try
            {
                await _tunifyDbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(Id))
                {
                    return null;
                }
            }

            return song;
        }
        private bool SongExists(int id)
        {
            return (_tunifyDbContext.Songs?.Any(e => e.SongId == id)).GetValueOrDefault();
        }
    }
}
