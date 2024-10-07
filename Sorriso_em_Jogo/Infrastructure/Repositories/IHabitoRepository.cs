using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IHabitoRepository
    {
        Task<Habito?> GetByIdAsync(int id);  
        Task<IEnumerable<Habito>> GetAllAsync();  
        Task AddAsync(Habito habito);  
        Task UpdateAsync(Habito habito);  
        Task DeleteAsync(int id);  
    }
}
