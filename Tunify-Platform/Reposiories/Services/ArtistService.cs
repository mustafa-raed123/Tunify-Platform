using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Reposiories.Interface;

namespace Tunify_Platform.Reposiories.Services
{
    public class ArtistService : IArtist
    {
        private readonly TunifyDbContext _tunifyDbContext;
        public ArtistService(TunifyDbContext tunifyDbContext)
        {
            _tunifyDbContext = tunifyDbContext;
        }
        public async Task<Artist> CreateArtist(Artist artist)
        {
            _tunifyDbContext.artists.Add(artist);
            await _tunifyDbContext.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> DeleteArtist(int Id)
        {
            if (_tunifyDbContext.artists == null)
            {
                return null;
            }
            var Artist = await _tunifyDbContext.artists.FindAsync(Id);
            if (Artist == null) return null;
          
            _tunifyDbContext.Entry(Artist).State = EntityState.Deleted;
            await _tunifyDbContext.SaveChangesAsync();
            return Artist;
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            if (_tunifyDbContext.artists == null) return null;
           
            var Artists = await _tunifyDbContext.artists.ToListAsync();
            return Artists;
        }

        public async Task<Artist> GetArtistById(int id)
        {
            var Artist = await _tunifyDbContext.artists.FindAsync(id);
            if (Artist == null)
            {

                return null;
            }
            return Artist;
        }

        public async Task<Artist> UpdateArtist(int Id, Artist astist)
        {
            _tunifyDbContext.Entry(astist).State = EntityState.Modified;
            try
            {
                await _tunifyDbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(Id))
                {
                    return null;
                }
            }

            return astist;
        }
        private bool ArtistExists(int id)
        {
            return (_tunifyDbContext.artists?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
