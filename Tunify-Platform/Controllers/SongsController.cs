using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Reposiories.Interface;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISong _song;

        public SongsController(ISong context)
        {
            _song = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {  
            var AllSongs = await _song.GetAllSongs();
            if (AllSongs == null) return NotFound();
            return Ok(AllSongs);
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _song.GetSongById(id);
            if (song == null) return NotFound();
            return Ok(song);
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult  > PutSong(int id, Song song)
        {
            if (id != song.SongId)
            {
                return BadRequest();
            }
            var UpdateSong = await _song.UpdateSong(id, song);

            if (UpdateSong == null)
            {
                return NotFound();
            }

            return Ok(UpdateSong);
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            return await _song.CreateSong(song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(int id)
        {
            var deleteSong = await _song.DeleteSong(id);
            if (deleteSong == null) return NotFound();
            else
                return deleteSong;
        }

 
    }
}
