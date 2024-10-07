using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs;
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RegistroHabitoController : ControllerBase
{
    private readonly RegistroHabitoService _registroHabitoService;

    public RegistroHabitoController(RegistroHabitoService registroHabitoService)
    {
        _registroHabitoService = registroHabitoService;
    }

    // GET api/registrohabito
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegistroHabitoDTO>>> Get()
    {
        var registros = await _registroHabitoService.GetAllRegistrosHabitoAsync();
        var registrosDto = registros.Select(r => new RegistroHabitoDTO
        {
            Id_habito = r.Id_habito,
            Data = r.Data,
            Imagem = r.Imagem,
            Observacoes = r.Observacoes,
            UsuarioId = r.UsuarioId,
            UsuarioNome = r.Usuario.Nome, 
            HabitoId = r.HabitoId,
            HabitoDescricao = r.Habito.Descricao 
        }).ToList();

        return Ok(registrosDto);
    }

    // GET api/registrohabito/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<RegistroHabitoDTO>> Get(int id)
    {
        try
        {
            var registro = await _registroHabitoService.GetRegistroHabitoByIdAsync(id);
            var registroDto = new RegistroHabitoDTO
            {
                Id_habito = registro.Id_habito,
                Data = registro.Data,
                Imagem = registro.Imagem,
                Observacoes = registro.Observacoes,
                UsuarioId = registro.UsuarioId,
                UsuarioNome = registro.Usuario.Nome, 
                HabitoId = registro.HabitoId,
                HabitoDescricao = registro.Habito.Descricao 
            };
            return Ok(registroDto);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // POST api/registrohabito
    [HttpPost]
    public async Task<ActionResult<RegistroHabitoDTO>> Post([FromBody] RegistroHabitoCreateDTO registroHabitoDto)
    {
        try
        {
            var registroHabito = new RegistroHabito
            {
                Data = registroHabitoDto.Data,
                Imagem = registroHabitoDto.Imagem,
                Observacoes = registroHabitoDto.Observacoes,
                UsuarioId = registroHabitoDto.UsuarioId,
                HabitoId = registroHabitoDto.HabitoId
            };
            await _registroHabitoService.AddRegistroHabitoAsync(registroHabito);

            var resultDto = new RegistroHabitoDTO
            {
                Id_habito = registroHabito.Id_habito,
                Data = registroHabito.Data,
                Imagem = registroHabito.Imagem,
                Observacoes = registroHabito.Observacoes,
                UsuarioId = registroHabito.UsuarioId,
                UsuarioNome = registroHabito.Usuario.Nome,
                HabitoId = registroHabito.HabitoId,
                HabitoDescricao = registroHabito.Habito.Descricao
            };

            return CreatedAtAction(nameof(Get), new { id = registroHabito.Id_habito }, resultDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/registrohabito/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] RegistroHabitoUpdateDTO registroHabitoDto)
    {
        if (id != registroHabitoDto.Id_habito) return BadRequest();
        try
        {
            var registroHabito = new RegistroHabito
            {
                Id_habito = registroHabitoDto.Id_habito,
                Data = registroHabitoDto.Data,
                Imagem = registroHabitoDto.Imagem,
                Observacoes = registroHabitoDto.Observacoes,
                UsuarioId = registroHabitoDto.UsuarioId,
                HabitoId = registroHabitoDto.HabitoId
            };
            await _registroHabitoService.UpdateRegistroHabitoAsync(registroHabito);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/registrohabito/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _registroHabitoService.DeleteRegistroHabitoAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
