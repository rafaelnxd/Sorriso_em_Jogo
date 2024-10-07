using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class RecompensaRepository : IRecompensaRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public RecompensaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter recompensa pelo ID
        public async Task<Recompensa?> GetByIdAsync(int id)
        {
            return await _context.Recompensas.FindAsync(id);
        }

        // Implementação do método para obter todas as recompensas
        public async Task<IEnumerable<Recompensa>> GetAllAsync()
        {
            return await _context.Recompensas.ToListAsync();
        }

        // Implementação do método para adicionar nova recompensa
        public async Task AddAsync(Recompensa recompensa)
        {
            await _context.Recompensas.AddAsync(recompensa);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar uma recompensa existente
        public async Task UpdateAsync(Recompensa recompensa)
        {
            _context.Recompensas.Update(recompensa);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover uma recompensa pelo ID
        public async Task DeleteAsync(int id)
        {
            var recompensa = await _context.Recompensas.FindAsync(id);
            if (recompensa != null)
            {
                _context.Recompensas.Remove(recompensa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
