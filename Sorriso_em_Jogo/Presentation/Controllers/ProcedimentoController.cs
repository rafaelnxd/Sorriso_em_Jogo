using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.ProcedimentoDTOs;
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProcedimentoController : ControllerBase
{
    private readonly ProcedimentoService _procedimentoService;

    public ProcedimentoController(ProcedimentoService procedimentoService)
    {
        _procedimentoService = procedimentoService;
    }

    // GET: api/procedimento
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcedimentoDTO>>> Get()
    {
        var procedimentos = await _procedimentoService.GetAllProcedimentosAsync();
        var procedimentoDTOs = procedimentos.Select(p => new ProcedimentoDTO
        {
            Id_procedimento = p.Id_procedimento,
            Nome = p.Nome,
            Descricao = p.Descricao
        }).ToList();

        return Ok(procedimentoDTOs);
    }

    // GET: api/procedimento/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProcedimentoDTO>> Get(int id)
    {
        var procedimento = await _procedimentoService.GetProcedimentoByIdAsync(id);

        if (procedimento == null)
        {
            return NotFound();
        }

        var procedimentoDTO = new ProcedimentoDTO
        {
            Id_procedimento = procedimento.Id_procedimento,
            Nome = procedimento.Nome,
            Descricao = procedimento.Descricao
        };

        return Ok(procedimentoDTO);
    }

    // POST: api/procedimento
    [HttpPost]
    public async Task<ActionResult<ProcedimentoDTO>> Post([FromBody] ProcedimentoCreateDTO createDTO)
    {
        var novoProcedimento = new Procedimento
        {
            Nome = createDTO.Nome,
            Descricao = createDTO.Descricao
        };

        await _procedimentoService.AddProcedimentoAsync(novoProcedimento);

        var procedimentoDTO = new ProcedimentoDTO
        {
            Id_procedimento = novoProcedimento.Id_procedimento,
            Nome = novoProcedimento.Nome,
            Descricao = novoProcedimento.Descricao
        };

        return CreatedAtAction(nameof(Get), new { id = procedimentoDTO.Id_procedimento }, procedimentoDTO);
    }

    // PUT: api/procedimento/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProcedimentoUpdateDTO updateDTO)
    {
        if (id != updateDTO.Id_procedimento)
        {
            return BadRequest();
        }

        var procedimentoExistente = await _procedimentoService.GetProcedimentoByIdAsync(id);
        if (procedimentoExistente == null)
        {
            return NotFound();
        }

        procedimentoExistente.Nome = updateDTO.Nome;
        procedimentoExistente.Descricao = updateDTO.Descricao;

        await _procedimentoService.UpdateProcedimentoAsync(procedimentoExistente);

        return NoContent();
    }

    // DELETE: api/procedimento/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var procedimento = await _procedimentoService.GetProcedimentoByIdAsync(id);

        if (procedimento == null)
        {
            return NotFound();
        }

        await _procedimentoService.DeleteProcedimentoAsync(id);

        return NoContent();
    }
}
