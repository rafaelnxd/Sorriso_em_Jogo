using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IRegistroHabitoRepository
    {
        Task<RegistroHabito?> GetByIdAsync(int id);  
        Task<IEnumerable<RegistroHabito>> GetAllAsync();  
        Task AddAsync(RegistroHabito registroHabito);  
        Task UpdateAsync(RegistroHabito registroHabito);  
        Task DeleteAsync(int id);  
    }
}
