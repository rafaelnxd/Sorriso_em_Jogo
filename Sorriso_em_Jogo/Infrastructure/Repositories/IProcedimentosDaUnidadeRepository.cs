using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IProcedimentosDaUnidadeRepository
    {
        Task<ProcedimentosDaUnidade?> GetByIdsAsync(int unidadeId, int procedimentoId);  
        Task<IEnumerable<ProcedimentosDaUnidade>> GetAllAsync();  
        Task AddAsync(ProcedimentosDaUnidade procedimentosDaUnidade);  
        Task UpdateAsync(ProcedimentosDaUnidade procedimentosDaUnidade);  
        Task DeleteAsync(int unidadeId, int procedimentoId);  
    }
}
