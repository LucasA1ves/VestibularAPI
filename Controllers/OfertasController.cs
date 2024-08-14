using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularAPI.Data;
using VestibularAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace VestibularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertasController : ControllerBase
    {
        private readonly VestibularContext _context;

        public OfertasController(VestibularContext context)
        {
            _context = context;
        }

        // GET: api/ofertas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ofertas = await _context.Ofertas.ToListAsync();
            return Ok(ofertas);
        }

        // GET: api/ofertas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta == null)
            {
                return NotFound(new { Message = $"Oferta com ID {id} não encontrada." });
            }

            return Ok(oferta);
        }

        // POST: api/ofertas
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Oferta oferta)
        {
            if (oferta == null)
            {
                return BadRequest(new { Message = "Os dados da oferta não podem ser nulos." });
            }

            try
            {
                _context.Ofertas.Add(oferta);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = oferta.Id }, oferta);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Erro ao adicionar a oferta.", Details = ex.Message });
            }
        }

        // PUT: api/ofertas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Oferta oferta)
        {
            if (oferta == null)
            {
                return BadRequest(new { Message = "Os dados da oferta não podem ser nulos." });
            }

            if (id != oferta.Id)
            {
                return BadRequest(new { Message = "ID da oferta não corresponde ao ID fornecido." });
            }

            var ofertaExistente = await _context.Ofertas.FindAsync(id);
            if (ofertaExistente == null)
            {
                return NotFound(new { Message = $"Oferta com ID {id} não encontrada." });
            }

            // Atualizando os campos da oferta existente
            ofertaExistente.Nome = oferta.Nome;
            ofertaExistente.Descricao = oferta.Descricao;
            ofertaExistente.VagasDisponiveis = oferta.VagasDisponiveis;
            ofertaExistente.Inscricoes = oferta.Inscricoes; // Note que Inscricoes pode ser removido, se não for necessário.

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, new { Message = "Erro ao atualizar a oferta.", Details = ex.Message });
            }
        }

        // DELETE: api/ofertas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta == null)
            {
                return NotFound(new { Message = $"Oferta com ID {id} não encontrada." });
            }

            try
            {
                _context.Ofertas.Remove(oferta);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Erro ao excluir a oferta.", Details = ex.Message });
            }
        }

        private bool OfertaExists(int id)
        {
            return _context.Ofertas.Any(e => e.Id == id);
        }
    }
}
