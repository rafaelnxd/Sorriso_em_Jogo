using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class ProcedimentosController : Controller
    {
        private readonly ProcedimentoService _procedimentoService;

        public ProcedimentosController(ProcedimentoService procedimentoService)
        {
            _procedimentoService = procedimentoService;
        }

        // GET: Procedimentos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var procedimentos = await _procedimentoService.GetAllProcedimentosAsync();
            var procedimentoViewModels = procedimentos.Select(p => new ProcedimentoViewModel
            {
                Id_procedimento = p.Id_procedimento,
                Nome = p.Nome,
                Descricao = p.Descricao
            }).ToList();

            return View(procedimentoViewModels);
        }

        // GET: Procedimentos/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var procedimento = await _procedimentoService.GetProcedimentoByIdAsync(id);
            if (procedimento == null) return NotFound();

            var procedimentoViewModel = new ProcedimentoViewModel
            {
                Id_procedimento = procedimento.Id_procedimento,
                Nome = procedimento.Nome,
                Descricao = procedimento.Descricao
            };

            return View(procedimentoViewModel);
        }

        // GET: Procedimentos/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimentos/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcedimentoViewModel procedimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var procedimento = new Procedimento
                {
                    Nome = procedimentoViewModel.Nome,
                    Descricao = procedimentoViewModel.Descricao
                };

                await _procedimentoService.AddProcedimentoAsync(procedimento);
                return RedirectToAction(nameof(Index));
            }

            return View(procedimentoViewModel);
        }

        // GET: Procedimentos/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var procedimento = await _procedimentoService.GetProcedimentoByIdAsync(id);
            if (procedimento == null) return NotFound();

            var procedimentoViewModel = new ProcedimentoViewModel
            {
                Id_procedimento = procedimento.Id_procedimento,
                Nome = procedimento.Nome,
                Descricao = procedimento.Descricao
            };

            return View(procedimentoViewModel);
        }

        // POST: Procedimentos/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcedimentoViewModel procedimentoViewModel)
        {
            if (id != procedimentoViewModel.Id_procedimento) return NotFound();

            if (ModelState.IsValid)
            {
                var procedimentoExistente = await _procedimentoService.GetProcedimentoByIdAsync(id);
                if (procedimentoExistente == null) return NotFound();

                procedimentoExistente.Nome = procedimentoViewModel.Nome;
                procedimentoExistente.Descricao = procedimentoViewModel.Descricao;

                await _procedimentoService.UpdateProcedimentoAsync(procedimentoExistente);
                return RedirectToAction(nameof(Index));
            }

            return View(procedimentoViewModel);
        }

        // GET: Procedimentos/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var procedimento = await _procedimentoService.GetProcedimentoByIdAsync(id);
            if (procedimento == null) return NotFound();

            var procedimentoViewModel = new ProcedimentoViewModel
            {
                Id_procedimento = procedimento.Id_procedimento,
                Nome = procedimento.Nome,
                Descricao = procedimento.Descricao
            };

            return View(procedimentoViewModel);
        }

        // POST: Procedimentos/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _procedimentoService.DeleteProcedimentoAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var procedimento = await _procedimentoService.GetProcedimentoByIdAsync(id);
                var procedimentoViewModel = new ProcedimentoViewModel
                {
                    Id_procedimento = procedimento.Id_procedimento,
                    Nome = procedimento.Nome,
                    Descricao = procedimento.Descricao
                };
                return View("Delete", procedimentoViewModel);
            }
        }
    }
}
