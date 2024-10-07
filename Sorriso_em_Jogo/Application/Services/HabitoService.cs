using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class HabitoService
    {
        private readonly IHabitoRepository _habitoRepository;

        public HabitoService(IHabitoRepository habitoRepository)
        {
            _habitoRepository = habitoRepository;
        }

        // Obter um hábito por ID
        public async Task<Habito> GetHabitoByIdAsync(int id)
        {
            var habito = await _habitoRepository.GetByIdAsync(id);
            if (habito == null)
            {
                throw new KeyNotFoundException("Hábito não encontrado.");
            }
            return habito;
        }

        // Obter todos os hábitos
        public async Task<IEnumerable<Habito>> GetAllHabitosAsync()
        {
            return await _habitoRepository.GetAllAsync();
        }

        // Adicionar um novo hábito
        public async Task AddHabitoAsync(Habito habito)
        {
            // Regra de negócio: descrição, tipo e frequência ideal são obrigatórios
            if (string.IsNullOrWhiteSpace(habito.Descricao))
            {
                throw new ArgumentException("A descrição do hábito é obrigatória.");
            }
            if (string.IsNullOrWhiteSpace(habito.Tipo))
            {
                throw new ArgumentException("O tipo do hábito é obrigatório.");
            }
            if (habito.Frequencia_ideal <= 0)
            {
                throw new ArgumentException("A frequência ideal deve ser maior que zero.");
            }

            // Regra de negócio: o tipo do hábito deve ter no máximo 50 caracteres
            if (habito.Tipo.Length > 50)
            {
                throw new ArgumentException("O tipo do hábito pode ter no máximo 50 caracteres.");
            }

            // Adicionar o hábito ao banco de dados
            await _habitoRepository.AddAsync(habito);
        }

        // Atualizar um hábito existente
        public async Task UpdateHabitoAsync(Habito habito)
        {
            // Regra de negócio: validar os campos antes de atualizar
            if (habito.Id_habito <= 0)
            {
                throw new ArgumentException("ID de hábito inválido.");
            }
            if (string.IsNullOrWhiteSpace(habito.Descricao))
            {
                throw new ArgumentException("A descrição do hábito é obrigatória.");
            }
            if (string.IsNullOrWhiteSpace(habito.Tipo) || habito.Tipo.Length > 50)
            {
                throw new ArgumentException("O tipo do hábito é inválido ou excede o tamanho permitido.");
            }
            if (habito.Frequencia_ideal <= 0)
            {
                throw new ArgumentException("A frequência ideal deve ser maior que zero.");
            }

            // Atualizar o hábito no banco de dados
            await _habitoRepository.UpdateAsync(habito);
        }

        // Deletar um hábito
        public async Task DeleteHabitoAsync(int id)
        {
            // Verificar se o hábito existe antes de deletar
            var habito = await _habitoRepository.GetByIdAsync(id);
            if (habito == null)
            {
                throw new KeyNotFoundException("Hábito não encontrado.");
            }

            // Regra de negócio: verificar se o hábito possui registros de hábitos associados
            if (habito.RegistrosHabito != null && habito.RegistrosHabito.Count > 0)
            {
                throw new InvalidOperationException("Não é possível excluir o hábito, pois há registros associados a ele.");
            }

           
            await _habitoRepository.DeleteAsync(id);
        }
    }
}
