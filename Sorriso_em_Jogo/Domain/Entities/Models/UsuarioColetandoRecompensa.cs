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
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }  

        [Required]
        public Usuario Usuario { get; set; } = new Usuario();  

        [Required]
        [ForeignKey("Recompensa")]
        [Column("RecompensaId")]
        public int RecompensaId { get; set; }  

        [Required]
        public Recompensa Recompensa { get; set; } = new Recompensa();  

        [Required]
        [DataType(DataType.Date)]
        [Column("DataColeta")]
        public DateTime DataColeta { get; set; }  
    }
}
