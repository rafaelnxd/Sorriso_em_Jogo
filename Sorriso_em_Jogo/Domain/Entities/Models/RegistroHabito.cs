using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("RegistroHabito")]
    public class RegistroHabito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Renomeado de Id_habito para Id

        [Required(ErrorMessage = "A data do registro é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [StringLength(255, ErrorMessage = "O link da imagem pode ter no máximo 255 caracteres")]
        public string Imagem { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "As observações podem ter no máximo 255 caracteres")]
        public string Observacoes { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } // Remova a inicialização com 'new Usuario()'

        [Required]
        [ForeignKey("Habito")]
        public int HabitoId { get; set; }

        public Habito Habito { get; set; } // Remova a inicialização com 'new Habito()'

        // Regras de Negócio...

        // (Métodos de validação permanecem os mesmos)
    }
}
