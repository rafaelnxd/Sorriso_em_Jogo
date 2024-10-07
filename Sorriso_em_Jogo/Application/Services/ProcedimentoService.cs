using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class ProcedimentoService
    {
        private readonly IProcedimentoRepository _procedimentoRepository;

        public ProcedimentoService(IProcedimentoRepository procedimentoRepository)
        {
            _procedimentoRepository = procedimentoRepository;
        }

        // Obter um procedimento por ID
        public async Task<Procedimento> GetProcedimentoByIdAsync(int id)
        {
            var procedimento = await _procedimentoRepository.GetByIdAsync(id);
            if (procedimento == null)
            {
                throw new KeyNotFoundException("Procedimento não encontrado.");
            }
            return procedimento;
        }

        // Obter todos os procedimentos
        public async Task<IEnumerable<Procedimento>> GetAllProcedimentosAsync()
        {
            return await _procedimentoRepository.GetAllAsync();
        }

        // Adicionar um novo procedimento
        public async Task AddProcedimentoAsync(Procedimento procedimento)
        {
            // Regra de negócio: nome é obrigatório
            if (string.IsNullOrWhiteSpace(procedimento.Nome))
            {
                throw new ArgumentException("O nome do procedimento é obrigatório.");
            }

            // Regra de negócio: descrição é opcional, mas se fornecida, deve ter no máximo 150 caracteres
            if (!string.IsNullOrWhiteSpace(procedimento.Descricao) && procedimento.Descricao.Length > 150)
            {
                throw new ArgumentException("A descrição pode ter no máximo 150 caracteres.");
            }

            // Adicionar o procedimento ao banco de dados
            await _procedimentoRepository.AddAsync(procedimento);
        }

        // Atualizar um procedimento existente
        public async Task UpdateProcedimentoAsync(Procedimento procedimento)
        {
            // Regra de negócio: validar os campos antes de atualizar
            if (procedimento.Id_procedimento <= 0)
            {
                throw new ArgumentException("ID de procedimento inválido.");
            }
            if (string.IsNullOrWhiteSpace(procedimento.Nome))
            {
                throw new ArgumentException("O nome do procedimento é obrigatório.");
            }
            if (!string.IsNullOrWhiteSpace(procedimento.Descricao) && procedimento.Descricao.Length > 150)
            {
                throw new ArgumentException("A descrição pode ter no máximo 150 caracteres.");
            }

            // Atualizar o procedimento no banco de dados
            await _procedimentoRepository.UpdateAsync(procedimento);
        }

        // Deletar um procedimento
        public async Task DeleteProcedimentoAsync(int id)
        {
            // Verificar se o procedimento existe antes de deletar
            var procedimento = await _procedimentoRepository.GetByIdAsync(id);
            if (procedimento == null)
            {
                throw new KeyNotFoundException("Procedimento não encontrado.");
            }

            // Regra de negócio: verificar se o procedimento está associado a uma unidade antes de deletar
            if (procedimento.ProcedimentosDaUnidade != null && procedimento.ProcedimentosDaUnidade.Count > 0)
            {
                throw new InvalidOperationException("Não é possível excluir o procedimento, pois ele está associado a uma ou mais unidades.");
            }


            await _procedimentoRepository.DeleteAsync(id);
        }
    }
}
