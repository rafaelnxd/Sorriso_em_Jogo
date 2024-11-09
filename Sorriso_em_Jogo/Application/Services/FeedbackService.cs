using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class FeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        // Obter um feedback por ID
        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException("Feedback não encontrado.");
            }
            return feedback;
        }

        // Obter todos os feedbacks
        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _feedbackRepository.GetAllAsync();
        }

        // Adicionar um novo feedback
        public async Task AddFeedbackAsync(Feedback feedback)
        {
            // Validações
            feedback.ValidarDataFeedback();
            feedback.ValidarComentario();

            // Adicionar o feedback ao banco de dados
            await _feedbackRepository.AddAsync(feedback);
        }

        // Atualizar um feedback existente
        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            // Validações
            if (feedback.Id_feedback <= 0)
            {
                throw new ArgumentException("ID de feedback inválido.");
            }
            feedback.ValidarDataFeedback();
            feedback.ValidarComentario();

            // Atualizar o feedback no banco de dados
            await _feedbackRepository.UpdateAsync(feedback);
        }

        // Deletar um feedback
        public async Task DeleteFeedbackAsync(int id)
        {
            // Verificar se o feedback existe antes de deletar
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException("Feedback não encontrado.");
            }

            await _feedbackRepository.DeleteAsync(id);
        }
    }
}
