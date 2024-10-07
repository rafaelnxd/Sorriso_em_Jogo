using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorriso_em_Jogo.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Obter um usuário por ID
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }
            return usuario;
        }

        // Obter todos os usuários
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        // Adicionar um novo usuário
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            // Regra de negócio: nome, email e senha são obrigatórios
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                throw new ArgumentException("O nome do usuário é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
            {
                throw new ArgumentException("Email inválido ou ausente.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                throw new ArgumentException("A senha é obrigatória.");
            }

            // Regra de negócio: o nome do usuário deve ter no mínimo 3 caracteres
            if (usuario.Nome.Length < 3)
            {
                throw new ArgumentException("O nome do usuário deve ter no mínimo 3 caracteres.");
            }

            // Adicionar o usuário ao banco de dados
            await _usuarioRepository.AddAsync(usuario);
        }

        // Atualizar um usuário existente
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            // Regra de negócio: validar os campos antes de atualizar
            if (usuario.Id_usuario <= 0)
            {
                throw new ArgumentException("ID de usuário inválido.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Nome) || usuario.Nome.Length < 3)
            {
                throw new ArgumentException("Nome do usuário inválido ou ausente.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
            {
                throw new ArgumentException("Email inválido ou ausente.");
            }

            // Atualizar o usuário no banco de dados
            await _usuarioRepository.UpdateAsync(usuario);
        }

        // Deletar um usuário
        public async Task DeleteUsuarioAsync(int id)
        {
            // Verificar se o usuário existe antes de deletar
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            // Regra de negócio: verificar se o usuário possui registros de hábitos antes de deletar
            if (usuario.RegistrosHabito != null && usuario.RegistrosHabito.Count > 0)
            {
                throw new InvalidOperationException("Não é possível excluir o usuário, pois ele possui registros de hábitos.");
            }


            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
