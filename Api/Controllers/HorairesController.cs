using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;
using Repo.Contexts;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorairesController : ControllerBase
    {
        private readonly EtablissementContext _context;

        public HorairesController(EtablissementContext context)
        {
            _context = context;
        }

        // GET: api/Horaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horaire>>> GetHoraires()
        {
            return await _context.Horaires.ToListAsync();
        }

        // GET: api/Horaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Horaire>> GetHoraire(Guid id)
        {
            var horaire = await _context.Horaires.FindAsync(id);

            if (horaire == null)
            {
                return NotFound();
            }

            return horaire;
        }

        // PUT: api/Horaires/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoraire(Guid id, Horaire horaire)
        {
            if (id != horaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(horaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoraireExists(id))
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

        // POST: api/Horaires
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Horaire>> PostHoraire(Horaire horaire)
        {
            _context.Horaires.Add(horaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoraire", new { id = horaire.Id }, horaire);
        }

        // DELETE: api/Horaires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Horaire>> DeleteHoraire(Guid id)
        {
            var horaire = await _context.Horaires.FindAsync(id);
            if (horaire == null)
            {
                return NotFound();
            }

            _context.Horaires.Remove(horaire);
            await _context.SaveChangesAsync();

            return horaire;
        }

        private bool HoraireExists(Guid id)
        {
            return _context.Horaires.Any(e => e.Id == id);
        }
    }
}
