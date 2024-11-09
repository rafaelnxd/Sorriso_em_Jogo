using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter feedback pelo ID
        public async Task<Feedback?> GetByIdAsync(int id)
        {
            return await _context.Feedbacks
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(f => f.Id_feedback == id);
        }

        // Implementação do método para obter todos os feedbacks
        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks
                .Include(f => f.Usuario)
                .ToListAsync();
        }

        // Implementação do método para adicionar novo feedback
        public async Task AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar um feedback existente
        public async Task UpdateAsync(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover um feedback pelo ID
        public async Task DeleteAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}
