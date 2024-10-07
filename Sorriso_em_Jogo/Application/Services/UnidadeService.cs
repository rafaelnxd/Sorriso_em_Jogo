using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class UnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeService(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        // Obter uma unidade por ID
        public async Task<Unidade> GetUnidadeByIdAsync(int id)
        {
            var unidade = await _unidadeRepository.GetByIdAsync(id);
            if (unidade == null)
            {
                throw new KeyNotFoundException("Unidade não encontrada.");
            }
            return unidade;
        }

        // Obter todas as unidades
        public async Task<IEnumerable<Unidade>> GetAllUnidadesAsync()
        {
            return await _unidadeRepository.GetAllAsync();
        }

        // Adicionar uma nova unidade
        public async Task AddUnidadeAsync(Unidade unidade)
        {
            // Regra de negócio: Verificar se os campos obrigatórios estão presentes
            if (string.IsNullOrWhiteSpace(unidade.Nome))
            {
                throw new ArgumentException("O nome da unidade é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(unidade.Estado))
            {
                throw new ArgumentException("O estado da unidade é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(unidade.Cidade))
            {
                throw new ArgumentException("A cidade da unidade é obrigatória.");
            }
            if (string.IsNullOrWhiteSpace(unidade.Endereco))
            {
                throw new ArgumentException("O endereço da unidade é obrigatório.");
            }

            // Adicionar a unidade ao banco de dados
            await _unidadeRepository.AddAsync(unidade);
        }

        // Atualizar uma unidade existente
        public async Task UpdateUnidadeAsync(Unidade unidade)
        {
            // Regra de negócio: Validar os campos antes de atualizar
            if (unidade.Id_unidade <= 0)
            {
                throw new ArgumentException("ID da unidade inválido.");
            }
            if (string.IsNullOrWhiteSpace(unidade.Nome))
            {
                throw new ArgumentException("O nome da unidade é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(unidade.Estado))
            {
                throw new ArgumentException("O estado da unidade é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(unidade.Cidade))
            {
                throw new ArgumentException("A cidade da unidade é obrigatória.");
            }
            if (string.IsNullOrWhiteSpace(unidade.Endereco))
            {
                throw new ArgumentException("O endereço da unidade é obrigatório.");
            }

            // Atualizar a unidade no banco de dados
            await _unidadeRepository.UpdateAsync(unidade);
        }

        // Deletar uma unidade
        public async Task DeleteUnidadeAsync(int id)
        {
            // Verificar se a unidade existe antes de deletar
            var unidade = await _unidadeRepository.GetByIdAsync(id);
            if (unidade == null)
            {
                throw new KeyNotFoundException("Unidade não encontrada.");
            }

            // Regra de negócio: verificar se a unidade está associada a algum procedimento antes de deletar
            if (unidade.ProcedimentosDaUnidade != null && unidade.ProcedimentosDaUnidade.Count > 0)
            {
                throw new InvalidOperationException("Não é possível excluir a unidade, pois ela está associada a um ou mais procedimentos.");
            }


            await _unidadeRepository.DeleteAsync(id);
        }
    }
}
