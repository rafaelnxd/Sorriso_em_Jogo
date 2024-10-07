using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.UnidadeDTOs;
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UnidadesController : ControllerBase
{
    private readonly UnidadeService _unidadeService;

    public UnidadesController(UnidadeService unidadeService)
    {
        _unidadeService = unidadeService;
    }

    // GET api/unidades
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnidadeDTO>>> Get()
    {
        var unidades = await _unidadeService.GetAllUnidadesAsync();
        var unidadeDTOs = unidades.Select(u => new UnidadeDTO
        {
            Id_unidade = u.Id_unidade,
            Nome = u.Nome,
            Estado = u.Estado,
            Cidade = u.Cidade,
            Endereco = u.Endereco
        });

        return Ok(unidadeDTOs);
    }

    // GET api/unidades/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UnidadeDTO>> Get(int id)
    {
        try
        {
            var unidade = await _unidadeService.GetUnidadeByIdAsync(id);
            var unidadeDTO = new UnidadeDTO
            {
                Id_unidade = unidade.Id_unidade,
                Nome = unidade.Nome,
                Estado = unidade.Estado,
                Cidade = unidade.Cidade,
                Endereco = unidade.Endereco
            };

            return Ok(unidadeDTO);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // POST api/unidades
    [HttpPost]
    public async Task<ActionResult<UnidadeDTO>> Post([FromBody] UnidadeCreateDTO unidadeCreateDTO)
    {
        try
        {
            var unidade = new Unidade
            {
                Nome = unidadeCreateDTO.Nome,
                Estado = unidadeCreateDTO.Estado,
                Cidade = unidadeCreateDTO.Cidade,
                Endereco = unidadeCreateDTO.Endereco
            };

            await _unidadeService.AddUnidadeAsync(unidade);

            var unidadeDTO = new UnidadeDTO
            {
                Id_unidade = unidade.Id_unidade,
                Nome = unidade.Nome,
                Estado = unidade.Estado,
                Cidade = unidade.Cidade,
                Endereco = unidade.Endereco
            };

            return CreatedAtAction(nameof(Get), new { id = unidadeDTO.Id_unidade }, unidadeDTO);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/unidades/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UnidadeUpdateDTO unidadeUpdateDTO)
    {
        if (id <= 0) return BadRequest("ID inválido.");

        try
        {
            var unidade = new Unidade
            {
                Id_unidade = id,
                Nome = unidadeUpdateDTO.Nome,
                Estado = unidadeUpdateDTO.Estado,
                Cidade = unidadeUpdateDTO.Cidade,
                Endereco = unidadeUpdateDTO.Endereco
            };

            await _unidadeService.UpdateUnidadeAsync(unidade);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/unidades/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _unidadeService.DeleteUnidadeAsync(id);
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
