using System;
using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class RegistroHabitoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data do registro é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [StringLength(255, ErrorMessage = "O link da imagem pode ter no máximo 255 caracteres")]
        [DataType(DataType.ImageUrl, ErrorMessage = "O link da imagem deve ser uma URL válida")]
        public string Imagem { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "As observações podem ter no máximo 255 caracteres")]
        public string Observacoes { get; set; } = string.Empty;

        [Required(ErrorMessage = "O usuário é obrigatório")]
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O hábito é obrigatório")]
        public int HabitoId { get; set; }
        public string HabitoDescricao { get; set; } = string.Empty;
    }
}
