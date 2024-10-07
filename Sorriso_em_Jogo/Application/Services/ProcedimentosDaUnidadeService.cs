using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class ProcedimentosDaUnidadeService
    {
        private readonly IProcedimentosDaUnidadeRepository _procedimentosDaUnidadeRepository;

        public ProcedimentosDaUnidadeService(IProcedimentosDaUnidadeRepository procedimentosDaUnidadeRepository)
        {
            _procedimentosDaUnidadeRepository = procedimentosDaUnidadeRepository;
        }

        // Obter um Procedimento da Unidade por UnidadeId e ProcedimentoId
        public async Task<ProcedimentosDaUnidade> GetProcedimentosDaUnidadeByIdsAsync(int unidadeId, int procedimentoId)
        {
            var procedimentoDaUnidade = await _procedimentosDaUnidadeRepository.GetByIdsAsync(unidadeId, procedimentoId);
            if (procedimentoDaUnidade == null)
            {
                throw new KeyNotFoundException("Procedimento da Unidade não encontrado.");
            }
            return procedimentoDaUnidade;
        }

        // Obter todos os Procedimentos das Unidades
        public async Task<IEnumerable<ProcedimentosDaUnidade>> GetAllProcedimentosDaUnidadeAsync()
        {
            return await _procedimentosDaUnidadeRepository.GetAllAsync();
        }

        // Adicionar um novo Procedimento da Unidade
        public async Task AddProcedimentosDaUnidadeAsync(ProcedimentosDaUnidade procedimentosDaUnidade)
        {
            // Regra de negócio: verificar se os IDs da unidade e do procedimento são válidos
            if (procedimentosDaUnidade.UnidadeId <= 0 || procedimentosDaUnidade.ProcedimentoId <= 0)
            {
                throw new ArgumentException("IDs de Unidade e Procedimento devem ser válidos.");
            }

            // Adicionar o Procedimento da Unidade ao banco de dados
            await _procedimentosDaUnidadeRepository.AddAsync(procedimentosDaUnidade);
        }

        // Atualizar um Procedimento da Unidade existente
        public async Task UpdateProcedimentosDaUnidadeAsync(ProcedimentosDaUnidade procedimentosDaUnidade)
        {
            // Regra de negócio: verificar se os IDs são válidos
            if (procedimentosDaUnidade.UnidadeId <= 0 || procedimentosDaUnidade.ProcedimentoId <= 0)
            {
                throw new ArgumentException("IDs de Unidade e Procedimento devem ser válidos.");
            }

            // Atualizar o Procedimento da Unidade no banco de dados
            await _procedimentosDaUnidadeRepository.UpdateAsync(procedimentosDaUnidade);
        }

        // Deletar um Procedimento da Unidade
        public async Task DeleteProcedimentosDaUnidadeAsync(int unidadeId, int procedimentoId)
        {
            // Verificar se o Procedimento da Unidade existe antes de deletar
            var procedimentoDaUnidade = await _procedimentosDaUnidadeRepository.GetByIdsAsync(unidadeId, procedimentoId);
            if (procedimentoDaUnidade == null)
            {
                throw new KeyNotFoundException("Procedimento da Unidade não encontrado.");
            }


            await _procedimentosDaUnidadeRepository.DeleteAsync(unidadeId, procedimentoId);
        }
    }
}
