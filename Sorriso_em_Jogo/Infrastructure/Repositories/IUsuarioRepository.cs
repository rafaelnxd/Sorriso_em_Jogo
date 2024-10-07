using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(int id);  
        Task<IEnumerable<Usuario>> GetAllAsync();  
        Task AddAsync(Usuario usuario);  
        Task UpdateAsync(Usuario usuario);  
        Task DeleteAsync(int id);  
    }
}
