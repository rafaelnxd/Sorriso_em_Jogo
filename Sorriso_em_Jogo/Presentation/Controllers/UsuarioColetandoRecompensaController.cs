using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class UsuarioColetandoRecompensaController : Controller
    {
        private readonly UsuarioColetandoRecompensaService _service;
        private readonly UsuarioService _usuarioService;
        private readonly RecompensaService _recompensaService;

        public UsuarioColetandoRecompensaController(
            UsuarioColetandoRecompensaService service,
            UsuarioService usuarioService,
            RecompensaService recompensaService)
        {
            _service = service;
            _usuarioService = usuarioService;
            _recompensaService = recompensaService;
        }

        // GET: UsuarioColetandoRecompensa
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var coletas = await _service.GetAllUsuarioColetandoRecompensasAsync();
            var viewModelList = coletas.Select(coleta => new UsuarioColetandoRecompensaViewModel
            {
                Id = coleta.Id,
                UsuarioId = coleta.UsuarioId,
                UsuarioNome = coleta.Usuario.Nome,
                RecompensaId = coleta.RecompensaId,
                RecompensaDescricao = coleta.Recompensa.Descricao,
                DataColeta = coleta.DataColeta
            }).ToList();

            return View(viewModelList);
        }

        // GET: UsuarioColetandoRecompensa/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var coleta = await _service.GetUsuarioColetandoRecompensaByIdAsync(id);
            if (coleta == null) return NotFound();

            var viewModel = new UsuarioColetandoRecompensaViewModel
            {
                Id = coleta.Id,
                UsuarioId = coleta.UsuarioId,
                UsuarioNome = coleta.Usuario.Nome,
                RecompensaId = coleta.RecompensaId,
                RecompensaDescricao = coleta.Recompensa.Descricao,
                DataColeta = coleta.DataColeta
            };

            return View(viewModel);
        }

        // GET: UsuarioColetandoRecompensa/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            // Carregar lista de usuários e recompensas para popular os dropdowns
            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Recompensas = await _recompensaService.GetAllRecompensasAsync();

            return View();
        }

        // POST: UsuarioColetandoRecompensa/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioColetandoRecompensaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var novaColeta = new UsuarioColetandoRecompensa
                {
                    UsuarioId = viewModel.UsuarioId,
                    RecompensaId = viewModel.RecompensaId,
                    DataColeta = viewModel.DataColeta
                };

                await _service.AddUsuarioColetandoRecompensaAsync(novaColeta);
                return RedirectToAction(nameof(Index));
            }

            // Se o ModelState não for válido, recarregar as listas para os dropdowns
            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Recompensas = await _recompensaService.GetAllRecompensasAsync();

            return View(viewModel);
        }

        // GET: UsuarioColetandoRecompensa/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var coleta = await _service.GetUsuarioColetandoRecompensaByIdAsync(id);
            if (coleta == null) return NotFound();

            var viewModel = new UsuarioColetandoRecompensaViewModel
            {
                Id = coleta.Id,
                UsuarioId = coleta.UsuarioId,
                RecompensaId = coleta.RecompensaId,
                DataColeta = coleta.DataColeta
            };

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Recompensas = await _recompensaService.GetAllRecompensasAsync();

            return View(viewModel);
        }

        // POST: UsuarioColetandoRecompensa/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioColetandoRecompensaViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var coletaExistente = await _service.GetUsuarioColetandoRecompensaByIdAsync(id);
                if (coletaExistente == null) return NotFound();

                coletaExistente.UsuarioId = viewModel.UsuarioId;
                coletaExistente.RecompensaId = viewModel.RecompensaId;
                coletaExistente.DataColeta = viewModel.DataColeta;

                await _service.UpdateUsuarioColetandoRecompensaAsync(coletaExistente);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Recompensas = await _recompensaService.GetAllRecompensasAsync();

            return View(viewModel);
        }

        // GET: UsuarioColetandoRecompensa/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coleta = await _service.GetUsuarioColetandoRecompensaByIdAsync(id);
            if (coleta == null) return NotFound();

            var viewModel = new UsuarioColetandoRecompensaViewModel
            {
                Id = coleta.Id,
                UsuarioId = coleta.UsuarioId,
                UsuarioNome = coleta.Usuario.Nome,
                RecompensaId = coleta.RecompensaId,
                RecompensaDescricao = coleta.Recompensa.Descricao,
                DataColeta = coleta.DataColeta
            };

            return View(viewModel);
        }

        // POST: UsuarioColetandoRecompensa/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteUsuarioColetandoRecompensaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
