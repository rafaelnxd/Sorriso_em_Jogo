using System;
using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id_feedback { get; set; }

        [Required(ErrorMessage = "A data do feedback é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório")]
        [StringLength(255, ErrorMessage = "O comentário pode ter no máximo 255 caracteres")]
        public string Comentario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O usuário é obrigatório")]
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;
    }
}
