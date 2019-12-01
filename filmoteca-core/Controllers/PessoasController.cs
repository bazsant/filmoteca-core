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
    public class PessoasController : ControllerBase
    {
        private readonly FILMOTECAContext _context;

        public PessoasController(FILMOTECAContext context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
        {
            return await _context.Pessoa.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.CdPessoa)
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
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

        // POST: api/Pessoas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoa", new { id = pessoa.CdPessoa }, pessoa);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.CdPessoa == id);
        }
    }
}
