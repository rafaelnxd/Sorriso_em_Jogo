using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class HabitosController : Controller  // Alterado para HabitosController
    {
        private readonly HabitoService _habitoService;

        public HabitosController(HabitoService habitoService)
        {
            _habitoService = habitoService;
        }

        // GET: Habitos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var habitos = await _habitoService.GetAllHabitosAsync();
            var habitoViewModels = habitos.Select(h => new HabitoViewModel
            {
                Id_habito = h.Id_habito,
                Descricao = h.Descricao,
                Tipo = h.Tipo,
                Frequencia_ideal = h.Frequencia_ideal
            }).ToList();

            return View(habitoViewModels);
        }

        // GET: Habitos/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var habito = await _habitoService.GetHabitoByIdAsync(id);
            if (habito == null) return NotFound();

            var habitoViewModel = new HabitoViewModel
            {
                Id_habito = habito.Id_habito,
                Descricao = habito.Descricao,
                Tipo = habito.Tipo,
                Frequencia_ideal = habito.Frequencia_ideal
            };

            return View(habitoViewModel);
        }

        // GET: Habitos/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitos/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HabitoViewModel habitoViewModel)
        {
            if (ModelState.IsValid)
            {
                var habito = new Habito
                {
                    Descricao = habitoViewModel.Descricao,
                    Tipo = habitoViewModel.Tipo,
                    Frequencia_ideal = habitoViewModel.Frequencia_ideal
                };

                await _habitoService.AddHabitoAsync(habito);
                return RedirectToAction(nameof(Index));
            }

            return View(habitoViewModel);
        }

        // GET: Habitos/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var habito = await _habitoService.GetHabitoByIdAsync(id);
            if (habito == null) return NotFound();

            var habitoViewModel = new HabitoViewModel
            {
                Id_habito = habito.Id_habito,
                Descricao = habito.Descricao,
                Tipo = habito.Tipo,
                Frequencia_ideal = habito.Frequencia_ideal
            };

            return View(habitoViewModel);
        }

        // POST: Habitos/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HabitoViewModel habitoViewModel)
        {
            if (id != habitoViewModel.Id_habito) return NotFound();

            if (ModelState.IsValid)
            {
                var habitoExistente = await _habitoService.GetHabitoByIdAsync(id);
                if (habitoExistente == null) return NotFound();

                habitoExistente.Descricao = habitoViewModel.Descricao;
                habitoExistente.Tipo = habitoViewModel.Tipo;
                habitoExistente.Frequencia_ideal = habitoViewModel.Frequencia_ideal;

                await _habitoService.UpdateHabitoAsync(habitoExistente);
                return RedirectToAction(nameof(Index));
            }

            return View(habitoViewModel);
        }

        // GET: Habitos/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var habito = await _habitoService.GetHabitoByIdAsync(id);
            if (habito == null) return NotFound();

            var habitoViewModel = new HabitoViewModel
            {
                Id_habito = habito.Id_habito,
                Descricao = habito.Descricao,
                Tipo = habito.Tipo,
                Frequencia_ideal = habito.Frequencia_ideal
            };

            return View(habitoViewModel);
        }

        // POST: Habitos/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _habitoService.DeleteHabitoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
