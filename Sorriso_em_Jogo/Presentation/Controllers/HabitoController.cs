using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.HabitoDTOs;
using Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs; 
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class HabitoController : ControllerBase
{
    private readonly HabitoService _habitoService;

    public HabitoController(HabitoService habitoService)
    {
        _habitoService = habitoService;
    }

    // GET api/habito
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HabitoDTO>>> Get()
    {
        var habitos = await _habitoService.GetAllHabitosAsync();

        // Converter para DTO
        var habitoDTOs = habitos.Select(h => new HabitoDTO
        {
            Id_habito = h.Id_habito,
            Descricao = h.Descricao,
            Tipo = h.Tipo,
            Frequencia_ideal = h.Frequencia_ideal,
            RegistrosHabito = h.RegistrosHabito.Select(r => new RegistroHabitoDTO 
            {
                Id_habito = r.Id_habito,
                Data = r.Data,
                Imagem = r.Imagem,
                Observacoes = r.Observacoes,
                UsuarioId = r.UsuarioId,
                UsuarioNome = r.Usuario.Nome, 
                HabitoId = r.HabitoId,
                HabitoDescricao = r.Habito.Descricao
            }).ToList()
        }).ToList();  

        return Ok(habitoDTOs);
    }

    // GET api/habito/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<HabitoDTO>> Get(int id)
    {
        try
        {
            var habito = await _habitoService.GetHabitoByIdAsync(id);

            
            var habitoDTO = new HabitoDTO
            {
                Id_habito = habito.Id_habito,
                Descricao = habito.Descricao,
                Tipo = habito.Tipo,
                Frequencia_ideal = habito.Frequencia_ideal,
                RegistrosHabito = habito.RegistrosHabito.Select(r => new RegistroHabitoDTO 
                {
                    Id_habito = r.Id_habito,
                    Data = r.Data,
                    Imagem = r.Imagem,
                    Observacoes = r.Observacoes,
                    UsuarioId = r.UsuarioId,
                    UsuarioNome = r.Usuario.Nome, 
                    HabitoId = r.HabitoId,
                    HabitoDescricao = r.Habito.Descricao
                }).ToList()
            };

            return Ok(habitoDTO);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // POST api/habito
    [HttpPost]
    public async Task<ActionResult<HabitoDTO>> Post([FromBody] HabitoCreateDTO habitoCreateDTO)
    {
        try
        {
            var habito = new Habito
            {
                Descricao = habitoCreateDTO.Descricao,
                Tipo = habitoCreateDTO.Tipo,
                Frequencia_ideal = habitoCreateDTO.Frequencia_ideal
            };

            await _habitoService.AddHabitoAsync(habito);

            
            var habitoDTO = new HabitoDTO
            {
                Id_habito = habito.Id_habito,
                Descricao = habito.Descricao,
                Tipo = habito.Tipo,
                Frequencia_ideal = habito.Frequencia_ideal
            };

            return CreatedAtAction(nameof(Get), new { id = habito.Id_habito }, habitoDTO);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/habito/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] HabitoUpdateDTO habitoUpdateDTO)
    {
        if (id != habitoUpdateDTO.Id_habito) return BadRequest();

        try
        {
            var habitoExistente = await _habitoService.GetHabitoByIdAsync(id);
            if (habitoExistente == null) return NotFound();

            
            habitoExistente.Descricao = habitoUpdateDTO.Descricao;
            habitoExistente.Tipo = habitoUpdateDTO.Tipo;
            habitoExistente.Frequencia_ideal = habitoUpdateDTO.Frequencia_ideal;

            await _habitoService.UpdateHabitoAsync(habitoExistente);

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/habito/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _habitoService.DeleteHabitoAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
