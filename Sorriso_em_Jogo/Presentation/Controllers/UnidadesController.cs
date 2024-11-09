using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class UnidadesController : Controller
    {
        private readonly UnidadeService _unidadeService;

        public UnidadesController(UnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }

        // GET: Unidades
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var unidades = await _unidadeService.GetAllUnidadesAsync();
            var unidadeViewModels = unidades.Select(u => new UnidadeViewModel
            {
                Id_unidade = u.Id_unidade,
                Nome = u.Nome,
                Estado = u.Estado,
                Cidade = u.Cidade,
                Endereco = u.Endereco
            });

            return View(unidadeViewModels);
        }

        // GET: Unidades/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var unidade = await _unidadeService.GetUnidadeByIdAsync(id);
            if (unidade == null) return NotFound();

            var unidadeViewModel = new UnidadeViewModel
            {
                Id_unidade = unidade.Id_unidade,
                Nome = unidade.Nome,
                Estado = unidade.Estado,
                Cidade = unidade.Cidade,
                Endereco = unidade.Endereco
            };

            return View(unidadeViewModel);
        }

        // GET: Unidades/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidades/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnidadeViewModel unidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                var unidade = new Unidade
                {
                    Nome = unidadeViewModel.Nome,
                    Estado = unidadeViewModel.Estado,
                    Cidade = unidadeViewModel.Cidade,
                    Endereco = unidadeViewModel.Endereco
                };

                await _unidadeService.AddUnidadeAsync(unidade);
                return RedirectToAction(nameof(Index));
            }

            return View(unidadeViewModel);
        }

        // GET: Unidades/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var unidade = await _unidadeService.GetUnidadeByIdAsync(id);
            if (unidade == null) return NotFound();

            var unidadeViewModel = new UnidadeViewModel
            {
                Id_unidade = unidade.Id_unidade,
                Nome = unidade.Nome,
                Estado = unidade.Estado,
                Cidade = unidade.Cidade,
                Endereco = unidade.Endereco
            };

            return View(unidadeViewModel);
        }

        // POST: Unidades/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnidadeViewModel unidadeViewModel)
        {
            if (id != unidadeViewModel.Id_unidade) return NotFound();

            if (ModelState.IsValid)
            {
                var unidade = new Unidade
                {
                    Id_unidade = unidadeViewModel.Id_unidade,
                    Nome = unidadeViewModel.Nome,
                    Estado = unidadeViewModel.Estado,
                    Cidade = unidadeViewModel.Cidade,
                    Endereco = unidadeViewModel.Endereco
                };

                await _unidadeService.UpdateUnidadeAsync(unidade);
                return RedirectToAction(nameof(Index));
            }

            return View(unidadeViewModel);
        }

        // GET: Unidades/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var unidade = await _unidadeService.GetUnidadeByIdAsync(id);
            if (unidade == null) return NotFound();

            var unidadeViewModel = new UnidadeViewModel
            {
                Id_unidade = unidade.Id_unidade,
                Nome = unidade.Nome,
                Estado = unidade.Estado,
                Cidade = unidade.Cidade,
                Endereco = unidade.Endereco
            };

            return View(unidadeViewModel);
        }

        // POST: Unidades/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unidadeService.DeleteUnidadeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
