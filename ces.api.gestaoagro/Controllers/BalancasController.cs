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
    public class BalancasController : ControllerBase
    {
        private readonly cessoftwareContext _context;

        public BalancasController(cessoftwareContext context)
        {
            _context = context;
        }

        // GET: api/Balancas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Balanca>>> GetBalancas()
        {
            return await _context.Balancas.ToListAsync();
        }

        // GET: api/Balancas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Balanca>> GetBalanca(int id)
        {
            var balanca = await _context.Balancas.FindAsync(id);

            if (balanca == null)
            {
                return NotFound();
            }

            return balanca;
        }

        // PUT: api/Balancas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBalanca(int id, Balanca balanca)
        {
            if (id != balanca.CliId)
            {
                return BadRequest();
            }

            _context.Entry(balanca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalancaExists(id))
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

        // POST: api/Balancas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Balanca>> PostBalanca(Balanca balanca)
        {
            _context.Balancas.Add(balanca);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BalancaExists(balanca.CliId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBalanca", new { id = balanca.CliId }, balanca);
        }

        // DELETE: api/Balancas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBalanca(int id)
        {
            var balanca = await _context.Balancas.FindAsync(id);
            if (balanca == null)
            {
                return NotFound();
            }

            _context.Balancas.Remove(balanca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BalancaExists(int id)
        {
            return _context.Balancas.Any(e => e.CliId == id);
        }
    }
}
