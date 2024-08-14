using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularAPI.Data;
using VestibularAPI.Models;
using System.Threading.Tasks;

namespace VestibularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly VestibularContext _context;

        public CandidatosController(VestibularContext context)
        {
            _context = context;
        }

        // GET: api/candidatos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var candidatos = await _context.Candidatos.ToListAsync();
            return Ok(candidatos);
        }

        // GET: api/candidatos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound(new { Message = $"Candidato com ID {id} não encontrado." });
            }

            return Ok(candidato);
        }

        // POST: api/candidatos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Candidato candidato)
        {
            if (candidato == null)
            {
                return BadRequest(new { Message = "Os dados do candidato não podem ser nulos." });
            }

            try
            {
                _context.Candidatos.Add(candidato);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = candidato.Id }, candidato);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Erro ao criar o candidato.", Details = ex.Message });
            }
        }

        // PUT: api/candidatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Candidato candidato)
        {
            if (candidato == null)
            {
                return BadRequest(new { Message = "Os dados do candidato não podem ser nulos." });
            }

            if (id != candidato.Id)
            {
                return BadRequest(new { Message = "ID do candidato não corresponde ao ID fornecido." });
            }

            var candidatoExistente = await _context.Candidatos.FindAsync(id);
            if (candidatoExistente == null)
            {
                return NotFound(new { Message = $"Candidato com ID {id} não encontrado." });
            }

            candidatoExistente.Nome = candidato.Nome;
            candidatoExistente.CPF = candidato.CPF;
            candidatoExistente.DataNascimento = candidato.DataNascimento;
            candidatoExistente.Email = candidato.Email;
            candidatoExistente.Telefone = candidato.Telefone;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CandidatoExists(id))
                {
                    return NotFound(new { Message = $"Candidato com ID {id} não encontrado para atualização." });
                }
                else
                {
                    return StatusCode(500, new { Message = "Erro ao atualizar o candidato.", Details = ex.Message });
                }
            }
        }

        // DELETE: api/candidatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound(new { Message = $"Candidato com ID {id} não encontrado para exclusão." });
            }

            _context.Candidatos.Remove(candidato);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Erro ao excluir o candidato.", Details = ex.Message });
            }
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
