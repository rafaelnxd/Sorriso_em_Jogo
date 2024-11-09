using System;
using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, ErrorMessage = "A senha pode ter no máximo 100 caracteres")]
        public string Senha { get; set; } = string.Empty;

        public DateTime Data_cadastro { get; set; }

        public float? Pontos_recompensa { get; set; }
    }
}
