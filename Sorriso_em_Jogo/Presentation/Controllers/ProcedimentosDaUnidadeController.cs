using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.ProcedimentosDaUnidadeDTOs;
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProcedimentosDaUnidadeController : ControllerBase
{
    private readonly ProcedimentosDaUnidadeService _procedimentosDaUnidadeService;

    public ProcedimentosDaUnidadeController(ProcedimentosDaUnidadeService procedimentosDaUnidadeService)
    {
        _procedimentosDaUnidadeService = procedimentosDaUnidadeService;
    }

    // GET: api/procedimentosdaunidade
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcedimentosDaUnidadeDTO>>> Get()
    {
        var procedimentosDaUnidade = await _procedimentosDaUnidadeService.GetAllProcedimentosDaUnidadeAsync();
        var procedimentosDaUnidadeDTOs = procedimentosDaUnidade.Select(pu => new ProcedimentosDaUnidadeDTO
        {
            UnidadeId = pu.UnidadeId,
            UnidadeNome = pu.Unidade.Nome,
            ProcedimentoId = pu.ProcedimentoId,
            ProcedimentoNome = pu.Procedimento.Nome
        }).ToList();

        return Ok(procedimentosDaUnidadeDTOs);
    }

    // GET: api/procedimentosdaunidade/{unidadeId}/{procedimentoId}
    [HttpGet("{unidadeId}/{procedimentoId}")]
    public async Task<ActionResult<ProcedimentosDaUnidadeDTO>> Get(int unidadeId, int procedimentoId)
    {
        var procedimentoDaUnidade = await _procedimentosDaUnidadeService.GetProcedimentosDaUnidadeByIdsAsync(unidadeId, procedimentoId);

        if (procedimentoDaUnidade == null)
        {
            return NotFound();
        }

        var procedimentoDaUnidadeDTO = new ProcedimentosDaUnidadeDTO
        {
            UnidadeId = procedimentoDaUnidade.UnidadeId,
            UnidadeNome = procedimentoDaUnidade.Unidade.Nome,
            ProcedimentoId = procedimentoDaUnidade.ProcedimentoId,
            ProcedimentoNome = procedimentoDaUnidade.Procedimento.Nome
        };

        return Ok(procedimentoDaUnidadeDTO);
    }

    // POST: api/procedimentosdaunidade
    [HttpPost]
    public async Task<ActionResult<ProcedimentosDaUnidadeDTO>> Post([FromBody] ProcedimentosDaUnidadeCreateDTO createDTO)
    {
        var novoProcedimentoDaUnidade = new ProcedimentosDaUnidade
        {
            UnidadeId = createDTO.UnidadeId,
            ProcedimentoId = createDTO.ProcedimentoId
        };

        await _procedimentosDaUnidadeService.AddProcedimentosDaUnidadeAsync(novoProcedimentoDaUnidade);

        var procedimentoDaUnidadeDTO = new ProcedimentosDaUnidadeDTO
        {
            UnidadeId = novoProcedimentoDaUnidade.UnidadeId,
            ProcedimentoId = novoProcedimentoDaUnidade.ProcedimentoId
        };

        return CreatedAtAction(nameof(Get), new { unidadeId = procedimentoDaUnidadeDTO.UnidadeId, procedimentoId = procedimentoDaUnidadeDTO.ProcedimentoId }, procedimentoDaUnidadeDTO);
    }

    // DELETE: api/procedimentosdaunidade/{unidadeId}/{procedimentoId}
    [HttpDelete("{unidadeId}/{procedimentoId}")]
    public async Task<IActionResult> Delete(int unidadeId, int procedimentoId)
    {
        var procedimentoDaUnidade = await _procedimentosDaUnidadeService.GetProcedimentosDaUnidadeByIdsAsync(unidadeId, procedimentoId);

        if (procedimentoDaUnidade == null)
        {
            return NotFound();
        }

        await _procedimentosDaUnidadeService.DeleteProcedimentosDaUnidadeAsync(unidadeId, procedimentoId);

        return NoContent();
    }
}
