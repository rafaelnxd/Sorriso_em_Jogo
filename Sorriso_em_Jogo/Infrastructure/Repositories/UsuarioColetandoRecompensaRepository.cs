using Sorriso_em_Jogo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorriso_em_Jogo.Infrastructure.Data;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public class UsuarioColetandoRecompensaRepository : IUsuarioColetandoRecompensaRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor injeta o ApplicationDbContext
        public UsuarioColetandoRecompensaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método para obter UsuarioColetandoRecompensa pelo ID
        public async Task<UsuarioColetandoRecompensa?> GetByIdAsync(int id)
        {
            return await _context.UsuariosColetandoRecompensa.FindAsync(id);
        }

        // Implementação do método para obter todos os UsuariosColetandoRecompensa
        public async Task<IEnumerable<UsuarioColetandoRecompensa>> GetAllAsync()
        {
            return await _context.UsuariosColetandoRecompensa.ToListAsync();
        }

        // Implementação do método para adicionar novo UsuarioColetandoRecompensa
        public async Task AddAsync(UsuarioColetandoRecompensa usuarioColetandoRecompensa)
        {
            await _context.UsuariosColetandoRecompensa.AddAsync(usuarioColetandoRecompensa);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para atualizar um UsuarioColetandoRecompensa existente
        public async Task UpdateAsync(UsuarioColetandoRecompensa usuarioColetandoRecompensa)
        {
            _context.UsuariosColetandoRecompensa.Update(usuarioColetandoRecompensa);
            await _context.SaveChangesAsync();
        }

        // Implementação do método para remover um UsuarioColetandoRecompensa pelo ID
        public async Task DeleteAsync(int id)
        {
            var usuarioColetandoRecompensa = await _context.UsuariosColetandoRecompensa.FindAsync(id);
            if (usuarioColetandoRecompensa != null)
            {
                _context.UsuariosColetandoRecompensa.Remove(usuarioColetandoRecompensa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
