using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.Services;
using Sorriso_em_Jogo.Application.ViewModels;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    [Route("[controller]")]
    public class FeedbacksController : Controller
    {
        private readonly FeedbackService _feedbackService;
        private readonly UsuarioService _usuarioService;

        public FeedbacksController(FeedbackService feedbackService, UsuarioService usuarioService)
        {
            _feedbackService = feedbackService;
            _usuarioService = usuarioService;
        }

        // GET: Feedbacks
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            var feedbackViewModels = feedbacks.Select(f => new FeedbackViewModel
            {
                Id_feedback = f.Id_feedback,
                Data = f.Data,
                Comentario = f.Comentario,
                UsuarioId = f.UsuarioId,
                UsuarioNome = f.Usuario.Nome
            }).ToList();

            return View(feedbackViewModels);
        }

        // GET: Feedbacks/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();

            var feedbackViewModel = new FeedbackViewModel
            {
                Id_feedback = feedback.Id_feedback,
                Data = feedback.Data,
                Comentario = feedback.Comentario,
                UsuarioId = feedback.UsuarioId,
                UsuarioNome = feedback.Usuario.Nome
            };

            return View(feedbackViewModel);
        }

        // GET: Feedbacks/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            return View();
        }

        // POST: Feedbacks/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                var feedback = new Feedback
                {
                    Data = feedbackViewModel.Data,
                    Comentario = feedbackViewModel.Comentario,
                    UsuarioId = feedbackViewModel.UsuarioId
                };

                try
                {
                    await _feedbackService.AddFeedbackAsync(feedback);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            return View(feedbackViewModel);
        }

        // GET: Feedbacks/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();

            var feedbackViewModel = new FeedbackViewModel
            {
                Id_feedback = feedback.Id_feedback,
                Data = feedback.Data,
                Comentario = feedback.Comentario,
                UsuarioId = feedback.UsuarioId
            };

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            return View(feedbackViewModel);
        }

        // POST: Feedbacks/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FeedbackViewModel feedbackViewModel)
        {
            if (id != feedbackViewModel.Id_feedback) return BadRequest();

            if (ModelState.IsValid)
            {
                var feedbackExistente = await _feedbackService.GetFeedbackByIdAsync(id);
                if (feedbackExistente == null) return NotFound();

                feedbackExistente.Data = feedbackViewModel.Data;
                feedbackExistente.Comentario = feedbackViewModel.Comentario;
                feedbackExistente.UsuarioId = feedbackViewModel.UsuarioId;

                try
                {
                    await _feedbackService.UpdateFeedbackAsync(feedbackExistente);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewBag.Usuarios = await _usuarioService.GetAllUsuariosAsync();
            return View(feedbackViewModel);
        }

        // GET: Feedbacks/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();

            var feedbackViewModel = new FeedbackViewModel
            {
                Id_feedback = feedback.Id_feedback,
                Data = feedback.Data,
                Comentario = feedback.Comentario,
                UsuarioId = feedback.UsuarioId,
                UsuarioNome = feedback.Usuario.Nome
            };

            return View(feedbackViewModel);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _feedbackService.DeleteFeedbackAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
                if (feedback == null) return NotFound();

                var feedbackViewModel = new FeedbackViewModel
                {
                    Id_feedback = feedback.Id_feedback,
                    Data = feedback.Data,
                    Comentario = feedback.Comentario,
                    UsuarioId = feedback.UsuarioId,
                    UsuarioNome = feedback.Usuario.Nome
                };

                return View("Delete", feedbackViewModel);
            }
        }
    }
}
