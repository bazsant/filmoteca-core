using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using filmoteca_core.Models;

namespace filmoteca_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilsController : ControllerBase
    {
        private readonly FILMOTECAContext _context;

        public PerfilsController(FILMOTECAContext context)
        {
            _context = context;
        }

        // GET: api/Perfils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfil()
        {
            return await _context.Perfil.ToListAsync();
        }

        // GET: api/Perfils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfil.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // PUT: api/Perfils/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (id != perfil.CdPerfil)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfils
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
            _context.Perfil.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.CdPerfil }, perfil);
        }

        // DELETE: api/Perfils/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Perfil>> DeletePerfil(int id)
        {
            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfil.Remove(perfil);
            await _context.SaveChangesAsync();

            return perfil;
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfil.Any(e => e.CdPerfil == id);
        }
    }
}
