using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularAPI.Data;
using VestibularAPI.Models;

namespace VestibularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricoesController : ControllerBase
    {
        private readonly VestibularContext _context;

        public InscricoesController(VestibularContext context)
        {
            _context = context;
        }

        // Obtém todas as inscrições
        [HttpGet]
        public IActionResult Get()
        {
            var inscricoes = _context.Inscricoes
                .ToList(); // Não incluir objetos relacionados

            return Ok(inscricoes);
        }

        // Obtém inscrições por CPF do candidato
        [HttpGet("cpf/{cpf}")]
        public IActionResult GetInscricoesPorCpf(string cpf)
        {
            var inscricoes = _context.Inscricoes
                .Where(i => _context.Candidatos.Any(c => c.Id == i.CandidatoId && c.CPF == cpf))
                .ToList(); // Não incluir objetos relacionados

            if (!inscricoes.Any())
            {
                return NotFound(new { Message = "Nenhuma inscrição encontrada para o CPF fornecido." });
            }

            return Ok(inscricoes);
        }

        // Obtém inscrições por ID da oferta
        [HttpGet("oferta/{id}")]
        public IActionResult GetInscricoesPorOferta(int id)
        {
            var inscricoes = _context.Inscricoes
                .Where(i => i.OfertaId == id)
                .ToList(); // Não incluir objetos relacionados

            if (!inscricoes.Any())
            {
                return NotFound(new { Message = "Nenhuma inscrição encontrada para a oferta fornecida." });
            }

            return Ok(inscricoes);
        }

        // Adiciona uma nova inscrição
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inscricao inscricao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar se o candidato, oferta e processo seletivo existem
            var candidato = await _context.Candidatos.FindAsync(inscricao.CandidatoId);
            var oferta = await _context.Ofertas.FindAsync(inscricao.OfertaId);
            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(inscricao.ProcessoSeletivoId);

            if (candidato == null || oferta == null || processoSeletivo == null)
            {
                return NotFound("Candidato, Oferta ou Processo Seletivo não encontrado.");
            }

            // Adicionar a nova inscrição ao contexto
            _context.Inscricoes.Add(inscricao);

            // Salvar as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Retornar uma resposta de sucesso
            return CreatedAtAction(nameof(Get), new { id = inscricao.Id }, inscricao);
        }

        // Atualiza uma inscrição existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Inscricao inscricao)
        {
            if (inscricao == null)
            {
                return BadRequest(new { Message = "Os dados da inscrição não podem ser nulos." });
            }

            if (id != inscricao.Id)
            {
                return BadRequest(new { Message = "ID da inscrição não corresponde ao ID fornecido." });
            }

            var inscricaoExistente = _context.Inscricoes.Find(id);
            if (inscricaoExistente == null)
            {
                return NotFound(new { Message = $"Inscrição com ID {id} não encontrada." });
            }

            // Atualiza os campos relevantes
            inscricaoExistente.NumInscricao = inscricao.NumInscricao;
            inscricaoExistente.DataInscricao = inscricao.DataInscricao;
            inscricaoExistente.CandidatoId = inscricao.CandidatoId;
            inscricaoExistente.OfertaId = inscricao.OfertaId;
            inscricaoExistente.ProcessoSeletivoId = inscricao.ProcessoSeletivoId;

            try
            {
                _context.SaveChanges();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, new { Message = "Erro ao atualizar a inscrição.", Details = ex.Message });
            }
        }

        // Remove uma inscrição
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inscricao = _context.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return NotFound(new { Message = $"Inscrição com ID {id} não encontrada." });
            }

            try
            {
                _context.Inscricoes.Remove(inscricao);
                _context.SaveChanges();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Erro ao excluir a inscrição.", Details = ex.Message });
            }
        }
    }
}
