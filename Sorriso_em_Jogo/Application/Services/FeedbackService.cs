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

        // Obtém um feedback por ID
        public async Task<Feedback> ObterPorIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException("Feedback não encontrado.");
            }

            return feedback;
        }

        // Obtém todos os feedbacks
        public async Task<IEnumerable<Feedback>> ObterTodosAsync()
        {
            return await _feedbackRepository.GetAllAsync();
        }

        // Adiciona um novo feedback
        public async Task AdicionarAsync(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            await _feedbackRepository.AddAsync(feedback);
        }

        // Atualiza um feedback existente
        public async Task AtualizarAsync(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            var feedbackExistente = await _feedbackRepository.GetByIdAsync(feedback.Id_feedback);
            if (feedbackExistente == null)
            {
                throw new KeyNotFoundException("Feedback não encontrado para atualização.");
            }

            await _feedbackRepository.UpdateAsync(feedback);
        }

        // Remove um feedback por ID
        public async Task RemoverAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null)
            {
                throw new KeyNotFoundException("Feedback não encontrado para remoção.");
            }

            await _feedbackRepository.DeleteAsync(id);
        }
    }
}
