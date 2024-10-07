using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs
{
    public class UpdateUsuarioColetandoRecompensaDTO
    {
        [Required]
        public int Id { get; set; } 

        [Required]
        public int UsuarioId { get; set; } 

        [Required]
        public int RecompensaId { get; set; } 

        [Required]
        public DateTime DataColeta { get; set; } 
    }
}
