using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs;
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuarioColetandoRecompensaController : ControllerBase
{
    private readonly UsuarioColetandoRecompensaService _usuarioColetandoRecompensaService;

    public UsuarioColetandoRecompensaController(UsuarioColetandoRecompensaService usuarioColetandoRecompensaService)
    {
        _usuarioColetandoRecompensaService = usuarioColetandoRecompensaService ?? throw new ArgumentNullException(nameof(usuarioColetandoRecompensaService));
    }

    // GET api/usuariocoletandorecompensa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioColetandoRecompensaDTO>>> Get()
    {
        var coletas = await _usuarioColetandoRecompensaService.GetAllUsuarioColetandoRecompensasAsync();

        // Convert domain models to DTOs
        var coletasDTO = coletas.Select(coleta => new UsuarioColetandoRecompensaDTO
        {
            Id = coleta.Id,
            UsuarioId = coleta.UsuarioId,
            UsuarioNome = coleta.Usuario.Nome,
            RecompensaId = coleta.RecompensaId,
            RecompensaDescricao = coleta.Recompensa.Descricao,
            DataColeta = coleta.DataColeta
        }).ToList();

        return Ok(coletasDTO);
    }

    // GET api/usuariocoletandorecompensa/{id:int}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UsuarioColetandoRecompensaDTO>> Get(int id)
    {
        try
        {
            var coleta = await _usuarioColetandoRecompensaService.GetUsuarioColetandoRecompensaByIdAsync(id);
            var coletaDTO = new UsuarioColetandoRecompensaDTO
            {
                Id = coleta.Id,
                UsuarioId = coleta.UsuarioId,
                UsuarioNome = coleta.Usuario.Nome,
                RecompensaId = coleta.RecompensaId,
                RecompensaDescricao = coleta.Recompensa.Descricao,
                DataColeta = coleta.DataColeta
            };

            return Ok(coletaDTO);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // POST api/usuariocoletandorecompensa
    [HttpPost]
    public async Task<ActionResult<UsuarioColetandoRecompensaDTO>> Post([FromBody] CreateUsuarioColetandoRecompensaDTO createDto)
    {
        try
        {
            var novaColeta = new UsuarioColetandoRecompensa
            {
                UsuarioId = createDto.UsuarioId,
                RecompensaId = createDto.RecompensaId,
                DataColeta = createDto.DataColeta
            };

            await _usuarioColetandoRecompensaService.AddUsuarioColetandoRecompensaAsync(novaColeta);

            var coletaDTO = new UsuarioColetandoRecompensaDTO
            {
                Id = novaColeta.Id,
                UsuarioId = novaColeta.UsuarioId,
                RecompensaId = novaColeta.RecompensaId,
                DataColeta = novaColeta.DataColeta
            };

            return CreatedAtAction(nameof(Get), new { id = novaColeta.Id }, coletaDTO);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/usuariocoletandorecompensa/{id:int}
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateUsuarioColetandoRecompensaDTO updateDto)
    {
        if (id != updateDto.Id) return BadRequest();

        try
        {
            var coletaExistente = await _usuarioColetandoRecompensaService.GetUsuarioColetandoRecompensaByIdAsync(id);
            coletaExistente.UsuarioId = updateDto.UsuarioId;
            coletaExistente.RecompensaId = updateDto.RecompensaId;
            coletaExistente.DataColeta = updateDto.DataColeta;

            await _usuarioColetandoRecompensaService.UpdateUsuarioColetandoRecompensaAsync(coletaExistente);

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // DELETE api/usuariocoletandorecompensa/{id:int}
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _usuarioColetandoRecompensaService.DeleteUsuarioColetandoRecompensaAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
