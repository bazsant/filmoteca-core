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
    public class ParametrizacaosController : ControllerBase
    {
        private readonly FILMOTECAContext _context;

        public ParametrizacaosController(FILMOTECAContext context)
        {
            _context = context;
        }

        // GET: api/Parametrizacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parametrizacao>>> GetParametrizacao()
        {
            return await _context.Parametrizacao.ToListAsync();
        }

        // GET: api/Parametrizacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parametrizacao>> GetParametrizacao(string id)
        {
            var parametrizacao = await _context.Parametrizacao.FindAsync(id);

            if (parametrizacao == null)
            {
                return NotFound();
            }

            return parametrizacao;
        }

        // PUT: api/Parametrizacaos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametrizacao(string id, Parametrizacao parametrizacao)
        {
            if (id != parametrizacao.DsChave)
            {
                return BadRequest();
            }

            _context.Entry(parametrizacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametrizacaoExists(id))
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

        // POST: api/Parametrizacaos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Parametrizacao>> PostParametrizacao(Parametrizacao parametrizacao)
        {
            _context.Parametrizacao.Add(parametrizacao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParametrizacaoExists(parametrizacao.DsChave))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParametrizacao", new { id = parametrizacao.DsChave }, parametrizacao);
        }

        // DELETE: api/Parametrizacaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parametrizacao>> DeleteParametrizacao(string id)
        {
            var parametrizacao = await _context.Parametrizacao.FindAsync(id);
            if (parametrizacao == null)
            {
                return NotFound();
            }

            _context.Parametrizacao.Remove(parametrizacao);
            await _context.SaveChangesAsync();

            return parametrizacao;
        }

        private bool ParametrizacaoExists(string id)
        {
            return _context.Parametrizacao.Any(e => e.DsChave == id);
        }
    }
}
