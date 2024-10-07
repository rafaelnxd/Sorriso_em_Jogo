using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IProcedimentoRepository
    {
        Task<Procedimento?> GetByIdAsync(int id);  
        Task<IEnumerable<Procedimento>> GetAllAsync();
        Task AddAsync(Procedimento procedimento);
        Task UpdateAsync(Procedimento procedimento);
        Task DeleteAsync(int id);
    }
}
