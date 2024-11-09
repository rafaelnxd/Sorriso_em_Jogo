using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class RecompensasController : Controller
    {
        private readonly RecompensaService _recompensaService;

        public RecompensasController(RecompensaService recompensaService)
        {
            _recompensaService = recompensaService;
        }

        // GET: Recompensas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var recompensas = await _recompensaService.GetAllRecompensasAsync();
            var recompensaViewModels = recompensas.Select(r => new RecompensaViewModel
            {
                Id_recompensa = r.Id_recompensa,
                Descricao = r.Descricao,
                Pontos_necessarios = r.Pontos_necessarios
            }).ToList();

            return View(recompensaViewModels);
        }

        // GET: Recompensas/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var recompensa = await _recompensaService.GetRecompensaByIdAsync(id);
            if (recompensa == null) return NotFound();

            var recompensaViewModel = new RecompensaViewModel
            {
                Id_recompensa = recompensa.Id_recompensa,
                Descricao = recompensa.Descricao,
                Pontos_necessarios = recompensa.Pontos_necessarios
            };

            return View(recompensaViewModel);
        }

        // GET: Recompensas/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recompensas/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecompensaViewModel recompensaViewModel)
        {
            if (ModelState.IsValid)
            {
                var recompensa = new Recompensa
                {
                    Descricao = recompensaViewModel.Descricao,
                    Pontos_necessarios = recompensaViewModel.Pontos_necessarios
                };

                await _recompensaService.AddRecompensaAsync(recompensa);
                return RedirectToAction(nameof(Index));
            }

            return View(recompensaViewModel);
        }

        // GET: Recompensas/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var recompensa = await _recompensaService.GetRecompensaByIdAsync(id);
            if (recompensa == null) return NotFound();

            var recompensaViewModel = new RecompensaViewModel
            {
                Id_recompensa = recompensa.Id_recompensa,
                Descricao = recompensa.Descricao,
                Pontos_necessarios = recompensa.Pontos_necessarios
            };

            return View(recompensaViewModel);
        }

        // POST: Recompensas/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RecompensaViewModel recompensaViewModel)
        {
            if (id != recompensaViewModel.Id_recompensa) return NotFound();

            if (ModelState.IsValid)
            {
                var recompensaExistente = await _recompensaService.GetRecompensaByIdAsync(id);
                if (recompensaExistente == null) return NotFound();

                recompensaExistente.Descricao = recompensaViewModel.Descricao;
                recompensaExistente.Pontos_necessarios = recompensaViewModel.Pontos_necessarios;

                await _recompensaService.UpdateRecompensaAsync(recompensaExistente);
                return RedirectToAction(nameof(Index));
            }

            return View(recompensaViewModel);
        }

        // GET: Recompensas/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recompensa = await _recompensaService.GetRecompensaByIdAsync(id);
            if (recompensa == null) return NotFound();

            var recompensaViewModel = new RecompensaViewModel
            {
                Id_recompensa = recompensa.Id_recompensa,
                Descricao = recompensa.Descricao,
                Pontos_necessarios = recompensa.Pontos_necessarios
            };

            return View(recompensaViewModel);
        }

        // POST: Recompensas/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _recompensaService.DeleteRecompensaAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var recompensa = await _recompensaService.GetRecompensaByIdAsync(id);
                var recompensaViewModel = new RecompensaViewModel
                {
                    Id_recompensa = recompensa.Id_recompensa,
                    Descricao = recompensa.Descricao,
                    Pontos_necessarios = recompensa.Pontos_necessarios
                };
                return View("Delete", recompensaViewModel);
            }
        }
    }
}
