using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class RecompensaService
    {
        private readonly IRecompensaRepository _recompensaRepository;

        public RecompensaService(IRecompensaRepository recompensaRepository)
        {
            _recompensaRepository = recompensaRepository;
        }

        // Obter uma recompensa por ID
        public async Task<Recompensa> GetRecompensaByIdAsync(int id)
        {
            var recompensa = await _recompensaRepository.GetByIdAsync(id);
            if (recompensa == null)
            {
                throw new KeyNotFoundException("Recompensa não encontrada.");
            }
            return recompensa;
        }

        // Obter todas as recompensas
        public async Task<IEnumerable<Recompensa>> GetAllRecompensasAsync()
        {
            return await _recompensaRepository.GetAllAsync();
        }

        // Adicionar uma nova recompensa
        public async Task AddRecompensaAsync(Recompensa recompensa)
        {
            // Regra de negócio: descrição e pontos necessários são obrigatórios
            if (string.IsNullOrWhiteSpace(recompensa.Descricao))
            {
                throw new ArgumentException("A descrição da recompensa é obrigatória.");
            }
            if (recompensa.Pontos_necessarios <= 0)
            {
                throw new ArgumentException("Os pontos necessários devem ser maiores que zero.");
            }

            // Adicionar a recompensa ao banco de dados
            await _recompensaRepository.AddAsync(recompensa);
        }

        // Atualizar uma recompensa existente
        public async Task UpdateRecompensaAsync(Recompensa recompensa)
        {
            // Regra de negócio: validar os campos antes de atualizar
            if (recompensa.Id_recompensa <= 0)
            {
                throw new ArgumentException("ID de recompensa inválido.");
            }
            if (string.IsNullOrWhiteSpace(recompensa.Descricao))
            {
                throw new ArgumentException("A descrição da recompensa é obrigatória.");
            }
            if (recompensa.Pontos_necessarios <= 0)
            {
                throw new ArgumentException("Os pontos necessários devem ser maiores que zero.");
            }

            // Atualizar a recompensa no banco de dados
            await _recompensaRepository.UpdateAsync(recompensa);
        }

        // Deletar uma recompensa
        public async Task DeleteRecompensaAsync(int id)
        {
            // Verificar se a recompensa existe antes de deletar
            var recompensa = await _recompensaRepository.GetByIdAsync(id);
            if (recompensa == null)
            {
                throw new KeyNotFoundException("Recompensa não encontrada.");
            }

            // Regra de negócio: verificar se a recompensa está sendo utilizada por algum usuário
            if (recompensa.UsuariosColetandoRecompensa != null && recompensa.UsuariosColetandoRecompensa.Count > 0)
            {
                throw new InvalidOperationException("Não é possível excluir a recompensa, pois está sendo utilizada.");
            }


            await _recompensaRepository.DeleteAsync(id);
        }
    }
}
