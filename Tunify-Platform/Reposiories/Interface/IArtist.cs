using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Reposiories.Interface
{
    public interface IArtist
    {
        public Task<IEnumerable<Artist>> GetAllArtists();
        public Task<Artist> UpdateArtist(int Id, Artist astist);
        public Task<Artist> DeleteArtist(int Id);
        public Task<Artist> GetArtistById(int id);
        public Task<Artist> CreateArtist(Artist artist);
    }
}
