using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.RecompensaDTOs;
using Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs;
                                                          
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RecompensaController : ControllerBase
{
    private readonly RecompensaService _recompensaService;

    public RecompensaController(RecompensaService recompensaService)
    {
        _recompensaService = recompensaService;
    }

    // GET api/recompensa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecompensaDTO>>> Get()
    {
        var recompensas = await _recompensaService.GetAllRecompensasAsync();

        // Mapeia as recompensas para DTOs, garantindo que o mapeamento para a lista de UsuarioColetandoRecompensaDTO esteja correto.
        var recompensaDTOs = recompensas.Select(r => new RecompensaDTO
        {
            Id_recompensa = r.Id_recompensa,
            Descricao = r.Descricao,
            Pontos_necessarios = r.Pontos_necessarios,
            UsuariosColetandoRecompensa = r.UsuariosColetandoRecompensa.Select(u => new UsuarioColetandoRecompensaDTO
            {
                Id = u.Id,
                UsuarioId = u.UsuarioId,
                UsuarioNome = u.Usuario.Nome,
                RecompensaId = u.RecompensaId,
                RecompensaDescricao = u.Recompensa.Descricao,
                DataColeta = u.DataColeta
            }).ToList() // Garantir que ToList() seja aplicado corretamente para a conversão.
        }).ToList();

        return Ok(recompensaDTOs);
    }

    // GET api/recompensa/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<RecompensaDTO>> Get(int id)
    {
        try
        {
            var recompensa = await _recompensaService.GetRecompensaByIdAsync(id);

            // Mapeia a recompensa para um DTO
            var recompensaDTO = new RecompensaDTO
            {
                Id_recompensa = recompensa.Id_recompensa,
                Descricao = recompensa.Descricao,
                Pontos_necessarios = recompensa.Pontos_necessarios,
                UsuariosColetandoRecompensa = recompensa.UsuariosColetandoRecompensa.Select(u => new UsuarioColetandoRecompensaDTO
                {
                    Id = u.Id,
                    UsuarioId = u.UsuarioId,
                    UsuarioNome = u.Usuario.Nome,
                    RecompensaId = u.RecompensaId,
                    RecompensaDescricao = u.Recompensa.Descricao,
                    DataColeta = u.DataColeta
                }).ToList() // Garantir que ToList() seja aplicado corretamente para a conversão.
            };

            return Ok(recompensaDTO);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // POST api/recompensa
    [HttpPost]
    public async Task<ActionResult<RecompensaDTO>> Post([FromBody] RecompensaCreateDTO recompensaCreateDTO)
    {
        try
        {
            // Mapear DTO para a entidade de domínio Recompensa
            var recompensa = new Recompensa
            {
                Descricao = recompensaCreateDTO.Descricao,
                Pontos_necessarios = recompensaCreateDTO.Pontos_necessarios
            };

            await _recompensaService.AddRecompensaAsync(recompensa);

            // Retornar o objeto criado como DTO
            var recompensaDTO = new RecompensaDTO
            {
                Id_recompensa = recompensa.Id_recompensa,
                Descricao = recompensa.Descricao,
                Pontos_necessarios = recompensa.Pontos_necessarios
            };

            return CreatedAtAction(nameof(Get), new { id = recompensaDTO.Id_recompensa }, recompensaDTO);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/recompensa/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] RecompensaUpdateDTO recompensaUpdateDTO)
    {
        if (id != recompensaUpdateDTO.Id_recompensa) return BadRequest();

        try
        {
            // Mapear DTO para a entidade de domínio Recompensa
            var recompensa = new Recompensa
            {
                Id_recompensa = recompensaUpdateDTO.Id_recompensa,
                Descricao = recompensaUpdateDTO.Descricao,
                Pontos_necessarios = recompensaUpdateDTO.Pontos_necessarios
            };

            await _recompensaService.UpdateRecompensaAsync(recompensa);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/recompensa/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _recompensaService.DeleteRecompensaAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
