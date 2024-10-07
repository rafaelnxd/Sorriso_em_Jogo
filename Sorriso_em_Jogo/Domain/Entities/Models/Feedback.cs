using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_feedback { get; set; }

        [Required(ErrorMessage = "A data do feedback é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório")]
        [StringLength(255, ErrorMessage = "O comentário pode ter no máximo 255 caracteres")]
        public string Comentario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = new Usuario();

        // Regras de Negócio

        // Valida se a data do feedback não é no futuro
        public void ValidarDataFeedback()
        {
            if (Data > DateTime.Now)
            {
                throw new InvalidOperationException("A data do feedback não pode ser no futuro.");
            }
        }

        // Valida o comentário do feedback
        public void ValidarComentario()
        {
            if (string.IsNullOrWhiteSpace(Comentario))
            {
                throw new ArgumentException("O comentário não pode ser vazio ou composto apenas de espaços em branco.");
            }
        }

  
    }
}
