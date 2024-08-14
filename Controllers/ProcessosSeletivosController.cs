using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularAPI.Data;
using VestibularAPI.Models;
using System.Threading.Tasks;

namespace VestibularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessosSeletivosController : ControllerBase
    {
        private readonly VestibularContext _context;

        public ProcessosSeletivosController(VestibularContext context)
        {
            _context = context;
        }

        // GET: api/processosseletivos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var processosSeletivos = await _context.ProcessosSeletivos
                .ToListAsync();
            return Ok(processosSeletivos);
        }

        // GET: api/processosseletivos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var processoSeletivo = await _context.ProcessosSeletivos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (processoSeletivo == null)
            {
                return NotFound(new { Message = $"Processo seletivo com ID {id} não encontrado." });
            }

            return Ok(processoSeletivo);
        }

        // POST: api/processosseletivos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProcessoSeletivo processoSeletivo)
        {
            if (processoSeletivo == null)
            {
                return BadRequest(new { Message = "Os dados do processo seletivo não podem ser nulos." });
            }

            try
            {
                _context.ProcessosSeletivos.Add(processoSeletivo);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = processoSeletivo.Id }, processoSeletivo);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Erro ao adicionar o processo seletivo.", Details = ex.Message });
            }
        }

        // PUT: api/processosseletivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProcessoSeletivo processoSeletivo)
        {
            if (processoSeletivo == null)
            {
                return BadRequest(new { Message = "Os dados do processo seletivo não podem ser nulos." });
            }

            if (id != processoSeletivo.Id)
            {
                return BadRequest(new { Message = "ID do processo seletivo não corresponde ao ID fornecido." });
            }

            var processoExistente = await _context.ProcessosSeletivos.FindAsync(id);
            if (processoExistente == null)
            {
                return NotFound(new { Message = $"Processo seletivo com ID {id} não encontrado." });
            }

            processoExistente.Descricao = processoSeletivo.Descricao;
            processoExistente.DataInicio = processoSeletivo.DataInicio;
            processoExistente.DataTermino = processoSeletivo.DataTermino;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, new { Message = "Erro ao atualizar o processo seletivo.", Details = ex.Message });
            }
        }

        // DELETE: api/processosseletivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(id);
            if (processoSeletivo == null)
            {
                return NotFound(new { Message = $"Processo seletivo com ID {id} não encontrado." });
            }

            try
            {
                _context.ProcessosSeletivos.Remove(processoSeletivo);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Erro ao excluir o processo seletivo.", Details = ex.Message });
            }
        }

        private bool ProcessoSeletivoExists(int id)
        {
            return _context.ProcessosSeletivos.Any(e => e.Id == id);
        }
    }
}
