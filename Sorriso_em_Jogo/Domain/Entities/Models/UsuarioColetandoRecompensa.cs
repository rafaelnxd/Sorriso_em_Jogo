using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("UsuarioColetandoRecompensa")]
    public class UsuarioColetandoRecompensa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } // Remova a inicialização

        [Required]
        [ForeignKey("Recompensa")]
        public int RecompensaId { get; set; }
        public Recompensa? Recompensa { get; set; } // Remova a inicialização

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataColeta { get; set; }
    }

}
