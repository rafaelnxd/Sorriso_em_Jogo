using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class ProcedimentoRepository : IProcedimentoRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public ProcedimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter procedimento pelo ID
        public async Task<Procedimento?> GetByIdAsync(int id)
        {
            return await _context.Procedimentos.FindAsync(id);
        }

        // Implementação do método para obter todos os procedimentos
        public async Task<IEnumerable<Procedimento>> GetAllAsync()
        {
            return await _context.Procedimentos.ToListAsync();
        }

        // Implementação do método para adicionar novo procedimento
        public async Task AddAsync(Procedimento procedimento)
        {
            await _context.Procedimentos.AddAsync(procedimento);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar um procedimento existente
        public async Task UpdateAsync(Procedimento procedimento)
        {
            _context.Procedimentos.Update(procedimento);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover um procedimento pelo ID
        public async Task DeleteAsync(int id)
        {
            var procedimento = await _context.Procedimentos.FindAsync(id);
            if (procedimento != null)
            {
                _context.Procedimentos.Remove(procedimento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
