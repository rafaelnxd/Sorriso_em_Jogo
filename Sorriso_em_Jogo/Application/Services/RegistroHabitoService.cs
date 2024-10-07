using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class RegistroHabitoService
    {
        private readonly IRegistroHabitoRepository _registroHabitoRepository;
        private readonly IUsuarioRepository _usuarioRepository; 
        private readonly IHabitoRepository _habitoRepository;    

        public RegistroHabitoService(IRegistroHabitoRepository registroHabitoRepository, IUsuarioRepository usuarioRepository, IHabitoRepository habitoRepository)
        {
            _registroHabitoRepository = registroHabitoRepository;
            _usuarioRepository = usuarioRepository;
            _habitoRepository = habitoRepository;
        }

        // Obter um registro de hábito por ID
        public async Task<RegistroHabito> GetRegistroHabitoByIdAsync(int id)
        {
            var registroHabito = await _registroHabitoRepository.GetByIdAsync(id);
            if (registroHabito == null)
            {
                throw new KeyNotFoundException("Registro de Hábito não encontrado.");
            }
            return registroHabito;
        }

        // Obter todos os registros de hábitos
        public async Task<IEnumerable<RegistroHabito>> GetAllRegistrosHabitoAsync()
        {
            return await _registroHabitoRepository.GetAllAsync();
        }

        // Adicionar um novo registro de hábito
        public async Task AddRegistroHabitoAsync(RegistroHabito registroHabito)
        {
            // Verificar se o usuário e o hábito existem
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(registroHabito.UsuarioId);
            if (usuarioExistente == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            var habitoExistente = await _habitoRepository.GetByIdAsync(registroHabito.HabitoId);
            if (habitoExistente == null)
            {
                throw new KeyNotFoundException("Hábito não encontrado.");
            }

            // Associar o usuário e o hábito existentes ao registro
            registroHabito.Usuario = usuarioExistente;
            registroHabito.Habito = habitoExistente;

            // Regra de negócio: Verificar se os campos obrigatórios estão presentes
            if (registroHabito.Data == default)
            {
                throw new ArgumentException("A data do registro de hábito é obrigatória.");
            }

            // Adicionar o registro de hábito ao banco de dados
            await _registroHabitoRepository.AddAsync(registroHabito);
        }

        // Atualizar um registro de hábito existente
        public async Task UpdateRegistroHabitoAsync(RegistroHabito registroHabito)
        {
            // Verificar se o registro existe
            var registroExistente = await _registroHabitoRepository.GetByIdAsync(registroHabito.Id_habito);
            if (registroExistente == null)
            {
                throw new KeyNotFoundException("Registro de Hábito não encontrado para atualização.");
            }

            // Verificar se o usuário e o hábito existem
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(registroHabito.UsuarioId);
            if (usuarioExistente == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            var habitoExistente = await _habitoRepository.GetByIdAsync(registroHabito.HabitoId);
            if (habitoExistente == null)
            {
                throw new KeyNotFoundException("Hábito não encontrado.");
            }

            // Atualizar as associações
            registroExistente.Usuario = usuarioExistente;
            registroExistente.Habito = habitoExistente;
            registroExistente.Data = registroHabito.Data;
            registroExistente.Imagem = registroHabito.Imagem;
            registroExistente.Observacoes = registroHabito.Observacoes;

            // Atualizar o registro de hábito no banco de dados
            await _registroHabitoRepository.UpdateAsync(registroExistente);
        }

        // Deletar um registro de hábito
        public async Task DeleteRegistroHabitoAsync(int id)
        {
            // Verificar se o registro de hábito existe antes de deletar
            var registroHabito = await _registroHabitoRepository.GetByIdAsync(id);
            if (registroHabito == null)
            {
                throw new KeyNotFoundException("Registro de Hábito não encontrado.");
            }

            // Deletar o registro de hábito
            await _registroHabitoRepository.DeleteAsync(id);
        }
    }
}
