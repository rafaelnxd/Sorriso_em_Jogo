using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class RegistroHabitosController : Controller
    {
        private readonly RegistroHabitoService _registroHabitoService;
        private readonly UsuarioService _usuarioService;
        private readonly HabitoService _habitoService;

        public RegistroHabitosController(
            RegistroHabitoService registroHabitoService,
            UsuarioService usuarioService,
            HabitoService habitoService)
        {
            _registroHabitoService = registroHabitoService;
            _usuarioService = usuarioService;
            _habitoService = habitoService;
        }

        // GET: RegistroHabitos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var registros = await _registroHabitoService.GetAllRegistrosHabitoAsync();
            var viewModelList = registros.Select(r => new RegistroHabitoViewModel
            {
                Id = r.Id,
                Data = r.Data,
                Imagem = r.Imagem,
                Observacoes = r.Observacoes,
                UsuarioId = r.UsuarioId,
                UsuarioNome = r.Usuario.Nome,
                HabitoId = r.HabitoId,
                HabitoDescricao = r.Habito.Descricao
            }).ToList();

            return View(viewModelList);
        }

        // GET: RegistroHabitos/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var registro = await _registroHabitoService.GetRegistroHabitoByIdAsync(id);
            if (registro == null) return NotFound();

            var viewModel = new RegistroHabitoViewModel
            {
                Id = registro.Id,
                Data = registro.Data,
                Imagem = registro.Imagem,
                Observacoes = registro.Observacoes,
                UsuarioId = registro.UsuarioId,
                UsuarioNome = registro.Usuario.Nome,
                HabitoId = registro.HabitoId,
                HabitoDescricao = registro.Habito.Descricao
            };

            return View(viewModel);
        }

        // GET: RegistroHabitos/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Habitos = await _habitoService.GetAllHabitosAsync();

            return View();
        }

        // POST: RegistroHabitos/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistroHabitoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var registroHabito = new RegistroHabito
                {
                    Data = viewModel.Data,
                    Imagem = viewModel.Imagem,
                    Observacoes = viewModel.Observacoes,
                    UsuarioId = viewModel.UsuarioId,
                    HabitoId = viewModel.HabitoId
                };

                await _registroHabitoService.AddRegistroHabitoAsync(registroHabito);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Habitos = await _habitoService.GetAllHabitosAsync();

            return View(viewModel);
        }

        // GET: RegistroHabitos/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var registro = await _registroHabitoService.GetRegistroHabitoByIdAsync(id);
            if (registro == null) return NotFound();

            var viewModel = new RegistroHabitoViewModel
            {
                Id = registro.Id,
                Data = registro.Data,
                Imagem = registro.Imagem,
                Observacoes = registro.Observacoes,
                UsuarioId = registro.UsuarioId,
                HabitoId = registro.HabitoId
            };

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Habitos = await _habitoService.GetAllHabitosAsync();

            return View(viewModel);
        }

        // POST: RegistroHabitos/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegistroHabitoViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var registroExistente = await _registroHabitoService.GetRegistroHabitoByIdAsync(id);
                if (registroExistente == null) return NotFound();

                registroExistente.Data = viewModel.Data;
                registroExistente.Imagem = viewModel.Imagem;
                registroExistente.Observacoes = viewModel.Observacoes;
                registroExistente.UsuarioId = viewModel.UsuarioId;
                registroExistente.HabitoId = viewModel.HabitoId;

                await _registroHabitoService.UpdateRegistroHabitoAsync(registroExistente);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            ViewBag.Habitos = await _habitoService.GetAllHabitosAsync();

            return View(viewModel);
        }

        // GET: RegistroHabitos/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registro = await _registroHabitoService.GetRegistroHabitoByIdAsync(id);
            if (registro == null) return NotFound();

            var viewModel = new RegistroHabitoViewModel
            {
                Id = registro.Id,
                Data = registro.Data,
                Imagem = registro.Imagem,
                Observacoes = registro.Observacoes,
                UsuarioId = registro.UsuarioId,
                UsuarioNome = registro.Usuario.Nome,
                HabitoId = registro.HabitoId,
                HabitoDescricao = registro.Habito.Descricao
            };

            return View(viewModel);
        }

        // POST: RegistroHabitos/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _registroHabitoService.DeleteRegistroHabitoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
