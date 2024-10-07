using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.FeedbackDTOs;
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly FeedbackService _feedbackService;

    public FeedbackController(FeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    // GET: api/feedback
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeedbackDTO>>> Get()
    {
        var feedbacks = await _feedbackService.ObterTodosAsync();
        var feedbackDtos = feedbacks.Select(f => new FeedbackDTO
        {
            Id_feedback = f.Id_feedback,
            Data = f.Data,
            Comentario = f.Comentario,
            UsuarioId = f.UsuarioId,
            UsuarioNome = f.Usuario.Nome 
        });

        return Ok(feedbackDtos);
    }

    // GET: api/feedback/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<FeedbackDTO>> Get(int id)
    {
        try
        {
            var feedback = await _feedbackService.ObterPorIdAsync(id);

            var feedbackDto = new FeedbackDTO
            {
                Id_feedback = feedback.Id_feedback,
                Data = feedback.Data,
                Comentario = feedback.Comentario,
                UsuarioId = feedback.UsuarioId,
                UsuarioNome = feedback.Usuario.Nome
            };

            return Ok(feedbackDto);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // POST: api/feedback
    [HttpPost]
    public async Task<ActionResult<FeedbackDTO>> Post([FromBody] FeedbackCreateDTO feedbackCreateDto)
    {
        try
        {
            var feedback = new Feedback
            {
                Data = feedbackCreateDto.Data,
                Comentario = feedbackCreateDto.Comentario,
                UsuarioId = feedbackCreateDto.UsuarioId
            };

            await _feedbackService.AdicionarAsync(feedback);

            var feedbackDto = new FeedbackDTO
            {
                Id_feedback = feedback.Id_feedback,
                Data = feedback.Data,
                Comentario = feedback.Comentario,
                UsuarioId = feedback.UsuarioId,
                UsuarioNome = feedback.Usuario.Nome
            };

            return CreatedAtAction(nameof(Get), new { id = feedback.Id_feedback }, feedbackDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/feedback/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] FeedbackUpdateDTO feedbackUpdateDto)
    {
        if (id != feedbackUpdateDto.Id_feedback) return BadRequest();

        try
        {
            var feedbackExistente = await _feedbackService.ObterPorIdAsync(id);
            if (feedbackExistente == null) return NotFound();

            feedbackExistente.Data = feedbackUpdateDto.Data;
            feedbackExistente.Comentario = feedbackUpdateDto.Comentario;
            feedbackExistente.UsuarioId = feedbackUpdateDto.UsuarioId;

            await _feedbackService.AtualizarAsync(feedbackExistente);

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/feedback/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _feedbackService.RemoverAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
