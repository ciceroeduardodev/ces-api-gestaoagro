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
    public class MovimentosController : ControllerBase
    {
        private readonly gestaoagroContext _context;

        public MovimentosController(gestaoagroContext context)
        {
            _context = context;
        }

        // GET: api/Movimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimento>>> GetMovimentos()
        {
            return await _context.Movimentos.ToListAsync();
        }

        // GET: api/Movimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimento>> GetMovimento(int id)
        {
            var movimento = await _context.Movimentos.FindAsync(id);

            if (movimento == null)
            {
                return NotFound();
            }

            return movimento;
        }

        // PUT: api/Movimentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimento(int id, Movimento movimento)
        {
            if (id != movimento.CliId)
            {
                return BadRequest();
            }

            _context.Entry(movimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentoExists(id))
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

        // POST: api/Movimentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movimento>> PostMovimento(Movimento movimento)
        {
            _context.Movimentos.Add(movimento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovimentoExists(movimento.CliId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovimento", new { id = movimento.CliId }, movimento);
        }

        // DELETE: api/Movimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimento(int id)
        {
            var movimento = await _context.Movimentos.FindAsync(id);
            if (movimento == null)
            {
                return NotFound();
            }

            _context.Movimentos.Remove(movimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimentoExists(int id)
        {
            return _context.Movimentos.Any(e => e.CliId == id);
        }
    }
}
