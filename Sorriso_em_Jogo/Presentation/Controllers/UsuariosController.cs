using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: Usuarios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            var usuarioViewModels = usuarios.Select(u => new UsuarioViewModel
            {
                Id_usuario = u.Id_usuario,
                Nome = u.Nome,
                Email = u.Email,
                Data_cadastro = u.Data_cadastro,
                Pontos_recompensa = u.Pontos_recompensa
            });

            return View(usuarioViewModels);
        }

        // GET: Usuarios/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();

            var usuarioViewModel = new UsuarioViewModel
            {
                Id_usuario = usuario.Id_usuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Data_cadastro = usuario.Data_cadastro,
                Pontos_recompensa = usuario.Pontos_recompensa
            };

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nome = usuarioViewModel.Nome,
                    Email = usuarioViewModel.Email,
                    Senha = usuarioViewModel.Senha,
                    Data_cadastro = DateTime.UtcNow,
                    Pontos_recompensa = 0
                };

                await _usuarioService.AddUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();

            var usuarioViewModel = new UsuarioViewModel
            {
                Id_usuario = usuario.Id_usuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Data_cadastro = usuario.Data_cadastro,
                Pontos_recompensa = usuario.Pontos_recompensa
            };

            return View(usuarioViewModel);
        }

        // POST: Usuarios/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id_usuario) return NotFound();

            if (ModelState.IsValid)
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario == null) return NotFound();

                usuario.Nome = usuarioViewModel.Nome;
                usuario.Email = usuarioViewModel.Email;
                usuario.Senha = usuarioViewModel.Senha;

                await _usuarioService.UpdateUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();

            var usuarioViewModel = new UsuarioViewModel
            {
                Id_usuario = usuario.Id_usuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Data_cadastro = usuario.Data_cadastro,
                Pontos_recompensa = usuario.Pontos_recompensa
            };

            return View(usuarioViewModel);
        }

        // POST: Usuarios/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
