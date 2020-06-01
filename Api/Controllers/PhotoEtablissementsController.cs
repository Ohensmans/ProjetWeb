using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;
using Repo.Contexts;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoEtablissementsController : ControllerBase
    {
        private readonly EtablissementContext _context;

        public PhotoEtablissementsController(EtablissementContext context)
        {
            _context = context;
        }

        // GET: api/PhotoEtablissements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoEtablissement>>> GetPhotosEtablissement()
        {
            return await _context.PhotosEtablissement.ToListAsync();
        }

        // GET: api/PhotoEtablissements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoEtablissement>> GetPhotoEtablissement(Guid id)
        {
            var photoEtablissement = await _context.PhotosEtablissement.FindAsync(id);

            if (photoEtablissement == null)
            {
                return NotFound();
            }

            return photoEtablissement;
        }

        // PUT: api/PhotoEtablissements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoEtablissement(Guid id, PhotoEtablissement photoEtablissement)
        {
            if (id != photoEtablissement.Id)
            {
                return BadRequest();
            }

            _context.Entry(photoEtablissement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoEtablissementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PhotoEtablissements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PhotoEtablissement>> PostPhotoEtablissement(PhotoEtablissement photoEtablissement)
        {
            _context.PhotosEtablissement.Add(photoEtablissement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoEtablissement", new { id = photoEtablissement.Id }, photoEtablissement);
        }

        // DELETE: api/PhotoEtablissements/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhotoEtablissement>> DeletePhotoEtablissement(Guid id)
        {
            var photoEtablissement = await _context.PhotosEtablissement.FindAsync(id);
            if (photoEtablissement == null)
            {
                return NotFound();
            }

            _context.PhotosEtablissement.Remove(photoEtablissement);
            await _context.SaveChangesAsync();

            return photoEtablissement;
        }

        private bool PhotoEtablissementExists(Guid id)
        {
            return _context.PhotosEtablissement.Any(e => e.Id == id);
        }
    }
}
