using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IUnidadeRepository
    {
        Task<Unidade?> GetByIdAsync(int id);  
        Task<IEnumerable<Unidade>> GetAllAsync();  
        Task AddAsync(Unidade unidade);  
        Task UpdateAsync(Unidade unidade);  
        Task DeleteAsync(int id);  
    }
}
