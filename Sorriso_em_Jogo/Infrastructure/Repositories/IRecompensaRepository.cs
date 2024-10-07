using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IRecompensaRepository
    {
        Task<Recompensa?> GetByIdAsync(int id);  
        Task<IEnumerable<Recompensa>> GetAllAsync();  
        Task AddAsync(Recompensa recompensa);  
        Task UpdateAsync(Recompensa recompensa); 
        Task DeleteAsync(int id);  
    }
}
