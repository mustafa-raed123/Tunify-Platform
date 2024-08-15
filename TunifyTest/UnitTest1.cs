//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.InMemory;
//using Moq;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Reposiories.Interface;
using Tunify_Platform.Reposiories.Services;
using Xunit;

namespace TunifyTest
{
    public class UnitTest1
    {
        private readonly TunifyDbContext _tunifyDbContext;
        private readonly SongService _songService;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<TunifyDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            _tunifyDbContext = new TunifyDbContext(options);
            _songService = new SongService(_tunifyDbContext);
        }

        [Fact]
        public async Task GetSongsForPlaylistTest()
        {
            // Arrange: Add playlist-song relationships to the in-memory database
            
            _tunifyDbContext.Songs.AddRange(new List<Song> {  
                new Song {SongId = 1 , title = "Billie Jean" ,    ArtistId = 1 , AlbumId = 1 , Genre = "Rock", duration = new TimeSpan(0 , 33 , 55)},
                new Song {SongId = 2 , title = "Bohemian Rhapsody" , ArtistId = 2 , AlbumId = 2 , Genre = "Rock", duration = new TimeSpan(0 , 55 , 55)},
                new Song {SongId = 3 , title = "Bohemian Rhapsody" , ArtistId = 2 , AlbumId = 2 , Genre = "Rock", duration = new TimeSpan(0 , 55 , 55)},
                new Song {SongId = 4 , title = "Bohemian Rhapsody" , ArtistId = 2 , AlbumId = 2 , Genre = "Rock", duration = new TimeSpan(0 , 55 , 55)}
            });

            _tunifyDbContext.playlists.AddRange(new List<Playlist> {
                 new Playlist{PlaylistId = 1,PlaylistName = "Rock Classics",CreateDate = new DateTime(2011,4,5) , UserId = 1},
                new Playlist{PlaylistId = 2,PlaylistName = "Pop Hits",CreateDate = new DateTime(2013,5,7) , UserId = 2}     ,
                new Playlist{PlaylistId = 3,PlaylistName = "Pop Hits",CreateDate = new DateTime(2013,5,7) , UserId = 3}

            });
            _tunifyDbContext.playlistSongs.Add(new PlaylistSong { PlaylistId = 1, SongId = 3 });
            _tunifyDbContext.playlistSongs.Add(new PlaylistSong { PlaylistId = 1, SongId = 4 });
            await _tunifyDbContext.SaveChangesAsync();

            // Act: Retrieve songs for the given playlist ID
            var result = await _songService.GetSongsByPlaylist(1);

            // Assert: Verify the results
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}