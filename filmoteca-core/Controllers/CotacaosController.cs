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
    public class CotacaosController : ControllerBase
    {
        private readonly FILMOTECAContext _context;

        public CotacaosController(FILMOTECAContext context)
        {
            _context = context;
        }

        // GET: api/Cotacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotacao>>> GetCotacao()
        {
            return await _context.Cotacao.ToListAsync();
        }

        // GET: api/Cotacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cotacao>> GetCotacao(int id)
        {
            var cotacao = await _context.Cotacao.FindAsync(id);

            if (cotacao == null)
            {
                return NotFound();
            }

            return cotacao;
        }

        // PUT: api/Cotacaos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotacao(int id, Cotacao cotacao)
        {
            if (id != cotacao.CdCotacao)
            {
                return BadRequest();
            }

            _context.Entry(cotacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotacaoExists(id))
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

        // POST: api/Cotacaos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cotacao>> PostCotacao(Cotacao cotacao)
        {
            _context.Cotacao.Add(cotacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotacao", new { id = cotacao.CdCotacao }, cotacao);
        }

        // DELETE: api/Cotacaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cotacao>> DeleteCotacao(int id)
        {
            var cotacao = await _context.Cotacao.FindAsync(id);
            if (cotacao == null)
            {
                return NotFound();
            }

            _context.Cotacao.Remove(cotacao);
            await _context.SaveChangesAsync();

            return cotacao;
        }

        private bool CotacaoExists(int id)
        {
            return _context.Cotacao.Any(e => e.CdCotacao == id);
        }
    }
}
