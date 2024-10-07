using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IUsuarioColetandoRecompensaRepository
    {
        Task<UsuarioColetandoRecompensa?> GetByIdAsync(int id);  
        Task<IEnumerable<UsuarioColetandoRecompensa>> GetAllAsync();  
        Task AddAsync(UsuarioColetandoRecompensa usuarioColetandoRecompensa);  
        Task UpdateAsync(UsuarioColetandoRecompensa usuarioColetandoRecompensa);  
        Task DeleteAsync(int id);  
    }
}
