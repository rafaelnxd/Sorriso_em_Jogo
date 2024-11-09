using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class ProcedimentosDaUnidadeController : Controller
    {
        private readonly ProcedimentosDaUnidadeService _procedimentosDaUnidadeService;
        private readonly UnidadeService _unidadeService;
        private readonly ProcedimentoService _procedimentoService;

        public ProcedimentosDaUnidadeController(
            ProcedimentosDaUnidadeService procedimentosDaUnidadeService,
            UnidadeService unidadeService,
            ProcedimentoService procedimentoService)
        {
            _procedimentosDaUnidadeService = procedimentosDaUnidadeService;
            _unidadeService = unidadeService;
            _procedimentoService = procedimentoService;
        }

        // GET: ProcedimentosDaUnidade
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var procedimentosDaUnidade = await _procedimentosDaUnidadeService.GetAllProcedimentosDaUnidadeAsync();
            var viewModelList = procedimentosDaUnidade.Select(pu => new ProcedimentosDaUnidadeViewModel
            {
                UnidadeId = pu.UnidadeId,
                UnidadeNome = pu.Unidade.Nome,
                ProcedimentoId = pu.ProcedimentoId,
                ProcedimentoNome = pu.Procedimento.Nome
            }).ToList();

            return View(viewModelList);
        }

        // GET: ProcedimentosDaUnidade/Details/{unidadeId}/{procedimentoId}
        [HttpGet("Details/{unidadeId}/{procedimentoId}")]
        public async Task<IActionResult> Details(int unidadeId, int procedimentoId)
        {
            var procedimentoDaUnidade = await _procedimentosDaUnidadeService.GetProcedimentosDaUnidadeByIdsAsync(unidadeId, procedimentoId);

            if (procedimentoDaUnidade == null)
            {
                return NotFound();
            }

            var viewModel = new ProcedimentosDaUnidadeViewModel
            {
                UnidadeId = procedimentoDaUnidade.UnidadeId,
                UnidadeNome = procedimentoDaUnidade.Unidade.Nome,
                ProcedimentoId = procedimentoDaUnidade.ProcedimentoId,
                ProcedimentoNome = procedimentoDaUnidade.Procedimento.Nome
            };

            return View(viewModel);
        }

        // GET: ProcedimentosDaUnidade/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Unidades = await _unidadeService.GetAllUnidadesAsync();
            ViewBag.Procedimentos = await _procedimentoService.GetAllProcedimentosAsync();
            return View();
        }

        // POST: ProcedimentosDaUnidade/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcedimentosDaUnidadeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var procedimentosDaUnidade = new ProcedimentosDaUnidade
                {
                    UnidadeId = viewModel.UnidadeId,
                    ProcedimentoId = viewModel.ProcedimentoId
                };

                try
                {
                    await _procedimentosDaUnidadeService.AddProcedimentosDaUnidadeAsync(procedimentosDaUnidade);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewBag.Unidades = await _unidadeService.GetAllUnidadesAsync();
            ViewBag.Procedimentos = await _procedimentoService.GetAllProcedimentosAsync();
            return View(viewModel);
        }

        // GET: ProcedimentosDaUnidade/Edit/{unidadeId}/{procedimentoId}
        [HttpGet("Edit/{unidadeId}/{procedimentoId}")]
        public async Task<IActionResult> Edit(int unidadeId, int procedimentoId)
        {
            var procedimentoDaUnidade = await _procedimentosDaUnidadeService.GetProcedimentosDaUnidadeByIdsAsync(unidadeId, procedimentoId);

            if (procedimentoDaUnidade == null)
            {
                return NotFound();
            }

            var viewModel = new ProcedimentosDaUnidadeViewModel
            {
                UnidadeId = procedimentoDaUnidade.UnidadeId,
                UnidadeNome = procedimentoDaUnidade.Unidade.Nome,
                ProcedimentoId = procedimentoDaUnidade.ProcedimentoId,
                ProcedimentoNome = procedimentoDaUnidade.Procedimento.Nome
            };

            ViewBag.Unidades = await _unidadeService.GetAllUnidadesAsync();
            ViewBag.Procedimentos = await _procedimentoService.GetAllProcedimentosAsync();

            return View(viewModel);
        }

        // POST: ProcedimentosDaUnidade/Edit/{unidadeId}/{procedimentoId}
        [HttpPost("Edit/{unidadeId}/{procedimentoId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int unidadeId, int procedimentoId, ProcedimentosDaUnidadeViewModel viewModel)
        {
            if (unidadeId != viewModel.UnidadeId || procedimentoId != viewModel.ProcedimentoId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var procedimentosDaUnidade = new ProcedimentosDaUnidade
                {
                    UnidadeId = viewModel.UnidadeId,
                    ProcedimentoId = viewModel.ProcedimentoId
                };

                try
                {
                    await _procedimentosDaUnidadeService.UpdateProcedimentosDaUnidadeAsync(procedimentosDaUnidade);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewBag.Unidades = await _unidadeService.GetAllUnidadesAsync();
            ViewBag.Procedimentos = await _procedimentoService.GetAllProcedimentosAsync();

            return View(viewModel);
        }

        // GET: ProcedimentosDaUnidade/Delete/{unidadeId}/{procedimentoId}
        [HttpGet("Delete/{unidadeId}/{procedimentoId}")]
        public async Task<IActionResult> Delete(int unidadeId, int procedimentoId)
        {
            var procedimentosDaUnidade = await _procedimentosDaUnidadeService.GetProcedimentosDaUnidadeByIdsAsync(unidadeId, procedimentoId);
            if (procedimentosDaUnidade == null) return NotFound();

            var viewModel = new ProcedimentosDaUnidadeViewModel
            {
                UnidadeId = procedimentosDaUnidade.UnidadeId,
                UnidadeNome = procedimentosDaUnidade.Unidade.Nome,
                ProcedimentoId = procedimentosDaUnidade.ProcedimentoId,
                ProcedimentoNome = procedimentosDaUnidade.Procedimento.Nome
            };

            return View(viewModel);
        }

        // POST: ProcedimentosDaUnidade/DeleteConfirmed/{unidadeId}/{procedimentoId}
        [HttpPost("DeleteConfirmed/{unidadeId}/{procedimentoId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int unidadeId, int procedimentoId)
        {
            await _procedimentosDaUnidadeService.DeleteProcedimentosDaUnidadeAsync(unidadeId, procedimentoId);
            return RedirectToAction(nameof(Index));
        }
    }
}
