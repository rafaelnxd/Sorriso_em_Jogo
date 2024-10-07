using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs
{
    public class CreateUsuarioColetandoRecompensaDTO
    {
        [Required]
        public int UsuarioId { get; set; } 

        [Required]
        public int RecompensaId { get; set; } 

        [Required]
        public DateTime DataColeta { get; set; } 
    }
}
