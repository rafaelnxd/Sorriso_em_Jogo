using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class ProcedimentosDaUnidadeRepository : IProcedimentosDaUnidadeRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public ProcedimentosDaUnidadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter ProcedimentosDaUnidade por IDs
        public async Task<ProcedimentosDaUnidade?> GetByIdsAsync(int unidadeId, int procedimentoId)
        {
            return await _context.ProcedimentosDaUnidade
                .FirstOrDefaultAsync(p => p.UnidadeId == unidadeId && p.ProcedimentoId == procedimentoId);
        }

        // Implementação do método para obter todos os ProcedimentosDaUnidade
        public async Task<IEnumerable<ProcedimentosDaUnidade>> GetAllAsync()
        {
            return await _context.ProcedimentosDaUnidade.ToListAsync();
        }

        // Implementação do método para adicionar novo ProcedimentosDaUnidade
        public async Task AddAsync(ProcedimentosDaUnidade procedimentosDaUnidade)
        {
            await _context.ProcedimentosDaUnidade.AddAsync(procedimentosDaUnidade);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar um ProcedimentosDaUnidade existente
        public async Task UpdateAsync(ProcedimentosDaUnidade procedimentosDaUnidade)
        {
            _context.ProcedimentosDaUnidade.Update(procedimentosDaUnidade);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover ProcedimentosDaUnidade por IDs
        public async Task DeleteAsync(int unidadeId, int procedimentoId)
        {
            var procedimentoUnidade = await _context.ProcedimentosDaUnidade
                .FirstOrDefaultAsync(p => p.UnidadeId == unidadeId && p.ProcedimentoId == procedimentoId);

            if (procedimentoUnidade != null)
            {
                _context.ProcedimentosDaUnidade.Remove(procedimentoUnidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
