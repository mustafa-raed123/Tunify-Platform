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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _context;

        public ArtistsController(IArtist context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Getartists()
        {
            var AllArtist = await _context.GetAllArtists();
            if (AllArtist == null) return NotFound();
            return Ok(AllArtist);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var Artist = await _context.GetArtistById(id);
            if (Artist == null) return NotFound();
            return Ok(Artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest();
            }
            var UpdateArtist = await _context.UpdateArtist(id, artist);

            if (UpdateArtist == null)
            {
                return NotFound();
            }

            return Ok(UpdateArtist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            return await _context.CreateArtist(artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var DeleteArtist = await _context.DeleteArtist(id);
            if (DeleteArtist == null) return NotFound();
            else
                return Ok(DeleteArtist);
        }

     
    }
}
