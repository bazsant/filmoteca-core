using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using filmoteca_core.Models;
using System;

namespace filmoteca_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CotacaosController : ControllerBase
    {
        private readonly FILMOTECAContext _context;

        public CotacaosController(FILMOTECAContext context)
        {
            _context = context;
        }

        // GET: api/Cotacaos
        [HttpGet]
        public List<Cotacao2> GetCotacao()
        {
            var lista = _context.Cotacao.ToList();

            var listaAux = new List<Cotacao2>();

            lista.ForEach(x =>
            {
                listaAux.Add(new Cotacao2()
                {
                    CdCotacao = x.CdCotacao,
                    CdFilme = x.CdFilme,
                    CdPessoa = x.CdPessoa,
                    DsTitulo = _context.Filme.Where(y => y.CdFilme == x.CdFilme).FirstOrDefault().DsTitulo,
                    DtEntrega = x.DtEntrega,
                    NmPessoa = _context.Pessoa.Where(y => y.CdPessoa == x.CdPessoa).FirstOrDefault().NmPessoa,
                    VlValor = x.VlValor,
                    DtEntregaPrevista = x.DtEntregaPrevista
                });
            });

            return listaAux;
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

        // GET: api/Cotacaos/5
        [HttpGet("cliente/{id}")]
        public async Task<ActionResult<IEnumerable<Cotacao>>> GetCotacaoByCliente(int id)
        {
            var cotacao = _context.Cotacao.Where(x => x.CdPessoa == id && !x.FlEntregue);

            return await cotacao.ToListAsync();
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
        public async Task<IActionResult> PostCotacao(Cotacao cotacao)
        {
            _context.Cotacao.Add(cotacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotacao", new { id = cotacao.CdCotacao }, cotacao);
        }

        // POST: api/Cotacaos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("devolver")]
        public async Task<ActionResult<int>> PostCotacaoDevolver(List<CotacaoValor> cotacoes)
        {


            var cotacaoList = _context.Cotacao.Where(x => cotacoes.Exists(y => y.CdCotacao == x.CdCotacao)).ToList();

            cotacaoList.ForEach(x =>
            {
                x.DtEntrega = DateTime.Now;
                x.FlEntregue = true;
                x.VlValor = cotacoes.Where(y => y.CdCotacao == x.CdCotacao).FirstOrDefault().VlValor;

                var filme = _context.Filme.Where(y => y.CdFilme == x.CdFilme).FirstOrDefault();

                filme.VlEstoque += 1;

                _context.Entry(filme).State = EntityState.Modified;
                _context.Entry(x).State = EntityState.Modified;
            });

            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

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
