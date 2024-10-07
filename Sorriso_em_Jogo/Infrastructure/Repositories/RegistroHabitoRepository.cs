using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class RegistroHabitoRepository : IRegistroHabitoRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public RegistroHabitoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter RegistroHabito pelo ID
        public async Task<RegistroHabito?> GetByIdAsync(int id)
        {
            return await _context.RegistrosHabito.FindAsync(id);
        }

        // Implementação do método para obter todos os registros de hábitos
        public async Task<IEnumerable<RegistroHabito>> GetAllAsync()
        {
            return await _context.RegistrosHabito.ToListAsync();
        }

        // Implementação do método para adicionar novo RegistroHabito
        public async Task AddAsync(RegistroHabito registroHabito)
        {
            await _context.RegistrosHabito.AddAsync(registroHabito);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar um RegistroHabito existente
        public async Task UpdateAsync(RegistroHabito registroHabito)
        {
            _context.RegistrosHabito.Update(registroHabito);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover um RegistroHabito pelo ID
        public async Task DeleteAsync(int id)
        {
            var registroHabito = await _context.RegistrosHabito.FindAsync(id);
            if (registroHabito != null)
            {
                _context.RegistrosHabito.Remove(registroHabito);
                await _context.SaveChangesAsync();
            }
        }
    }
}
