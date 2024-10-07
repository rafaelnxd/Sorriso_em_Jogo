using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class UsuarioColetandoRecompensaService
    {
        private readonly IUsuarioColetandoRecompensaRepository _usuarioColetandoRecompensaRepository;

        public UsuarioColetandoRecompensaService(IUsuarioColetandoRecompensaRepository usuarioColetandoRecompensaRepository)
        {
            _usuarioColetandoRecompensaRepository = usuarioColetandoRecompensaRepository;
        }

        // Obter uma coleta de recompensa por ID
        public async Task<UsuarioColetandoRecompensa> GetUsuarioColetandoRecompensaByIdAsync(int id)
        {
            var usuarioColetandoRecompensa = await _usuarioColetandoRecompensaRepository.GetByIdAsync(id);
            if (usuarioColetandoRecompensa == null)
            {
                throw new KeyNotFoundException("Coleta de Recompensa não encontrada.");
            }
            return usuarioColetandoRecompensa;
        }

        // Obter todas as coletas de recompensas
        public async Task<IEnumerable<UsuarioColetandoRecompensa>> GetAllUsuarioColetandoRecompensasAsync()
        {
            return await _usuarioColetandoRecompensaRepository.GetAllAsync();
        }

        // Adicionar uma nova coleta de recompensa
        public async Task AddUsuarioColetandoRecompensaAsync(UsuarioColetandoRecompensa usuarioColetandoRecompensa)
        {
            // Regra de negócio: Verificar se os IDs do usuário e da recompensa são válidos
            if (usuarioColetandoRecompensa.UsuarioId <= 0 || usuarioColetandoRecompensa.RecompensaId <= 0)
            {
                throw new ArgumentException("IDs do usuário e da recompensa devem ser válidos.");
            }

            // Regra de negócio: Verificar se a data da coleta foi fornecida
            if (usuarioColetandoRecompensa.DataColeta == default)
            {
                throw new ArgumentException("A data da coleta é obrigatória.");
            }

            // Adicionar a coleta de recompensa ao banco de dados
            await _usuarioColetandoRecompensaRepository.AddAsync(usuarioColetandoRecompensa);
        }

        // Atualizar uma coleta de recompensa existente
        public async Task UpdateUsuarioColetandoRecompensaAsync(UsuarioColetandoRecompensa usuarioColetandoRecompensa)
        {
            // Regra de negócio: Verificar se os IDs são válidos
            if (usuarioColetandoRecompensa.Id <= 0)
            {
                throw new ArgumentException("ID da coleta de recompensa inválido.");
            }
            if (usuarioColetandoRecompensa.UsuarioId <= 0 || usuarioColetandoRecompensa.RecompensaId <= 0)
            {
                throw new ArgumentException("IDs do usuário e da recompensa devem ser válidos.");
            }

            // Regra de negócio: Verificar se a data da coleta foi fornecida
            if (usuarioColetandoRecompensa.DataColeta == default)
            {
                throw new ArgumentException("A data da coleta é obrigatória.");
            }

            // Atualizar a coleta de recompensa no banco de dados
            await _usuarioColetandoRecompensaRepository.UpdateAsync(usuarioColetandoRecompensa);
        }

        // Deletar uma coleta de recompensa
        public async Task DeleteUsuarioColetandoRecompensaAsync(int id)
        {
            // Verificar se a coleta de recompensa existe antes de deletar
            var usuarioColetandoRecompensa = await _usuarioColetandoRecompensaRepository.GetByIdAsync(id);
            if (usuarioColetandoRecompensa == null)
            {
                throw new KeyNotFoundException("Coleta de Recompensa não encontrada.");
            }

            await _usuarioColetandoRecompensaRepository.DeleteAsync(id);
        }
    }
}
