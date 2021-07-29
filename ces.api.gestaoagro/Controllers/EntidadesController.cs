using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ces.api.gestaoagro.Models;

namespace ces.api.gestaoagro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {
        private readonly gestaoagroContext _context;

        public EntidadesController(gestaoagroContext context)
        {
            _context = context;
        }

        // GET: api/Entidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entidade>>> GetEntidades()
        {
            return await _context.Entidades.ToListAsync();
        }

        // GET: api/Entidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entidade>> GetEntidade(int id)
        {
            var entidade = await _context.Entidades.FindAsync(id);

            if (entidade == null)
            {
                return NotFound();
            }

            return entidade;
        }

        // PUT: api/Entidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidade(int id, Entidade entidade)
        {
            if (id != entidade.CliId)
            {
                return BadRequest();
            }

            _context.Entry(entidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadeExists(id))
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

        // POST: api/Entidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entidade>> PostEntidade(Entidade entidade)
        {
            _context.Entidades.Add(entidade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntidadeExists(entidade.CliId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntidade", new { id = entidade.CliId }, entidade);
        }

        // DELETE: api/Entidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidade(int id)
        {
            var entidade = await _context.Entidades.FindAsync(id);
            if (entidade == null)
            {
                return NotFound();
            }

            _context.Entidades.Remove(entidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntidadeExists(int id)
        {
            return _context.Entidades.Any(e => e.CliId == id);
        }
    }
}
