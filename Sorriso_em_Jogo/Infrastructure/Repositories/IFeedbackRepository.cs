using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sorriso_em_Jogo.Infrastructure.Repositories
{
    public interface IFeedbackRepository
    {
        Task<Feedback?> GetByIdAsync(int id);  
        Task<IEnumerable<Feedback>> GetAllAsync();  
        Task AddAsync(Feedback feedback);  
        Task UpdateAsync(Feedback feedback);  
        Task DeleteAsync(int id);  
    }
}
