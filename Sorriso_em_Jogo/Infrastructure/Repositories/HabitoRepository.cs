using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class HabitoRepository : IHabitoRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public HabitoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter hábito pelo ID
        public async Task<Habito?> GetByIdAsync(int id)
        {
            return await _context.Habitos.FindAsync(id);
        }

        // Implementação do método para obter todos os hábitos
        public async Task<IEnumerable<Habito>> GetAllAsync()
        {
            return await _context.Habitos.ToListAsync();
        }

        // Implementação do método para adicionar novo hábito
        public async Task AddAsync(Habito habito)
        {
            await _context.Habitos.AddAsync(habito);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar um hábito existente
        public async Task UpdateAsync(Habito habito)
        {
            _context.Habitos.Update(habito);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover um hábito pelo ID
        public async Task DeleteAsync(int id)
        {
            var habito = await _context.Habitos.FindAsync(id);
            if (habito != null)
            {
                _context.Habitos.Remove(habito);
                await _context.SaveChangesAsync();
            }
        }
    }
}
