using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public UnidadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter Unidade pelo ID
        public async Task<Unidade?> GetByIdAsync(int id)
        {
            return await _context.Unidades.FindAsync(id);
        }

        // Implementação do método para obter todas as Unidades
        public async Task<IEnumerable<Unidade>> GetAllAsync()
        {
            return await _context.Unidades.ToListAsync();
        }

        // Implementação do método para adicionar nova Unidade
        public async Task AddAsync(Unidade unidade)
        {
            await _context.Unidades.AddAsync(unidade);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar uma Unidade existente
        public async Task UpdateAsync(Unidade unidade)
        {
            _context.Unidades.Update(unidade);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover uma Unidade pelo ID
        public async Task DeleteAsync(int id)
        {
            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade != null)
            {
                _context.Unidades.Remove(unidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
