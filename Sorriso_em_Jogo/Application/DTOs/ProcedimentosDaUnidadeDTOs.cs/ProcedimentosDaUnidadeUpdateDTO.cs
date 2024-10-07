using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.DTOs.ProcedimentosDaUnidadeDTOs
{
    public class ProcedimentosDaUnidadeUpdateDTO
    {
        [Required]
        public int UnidadeId { get; set; }  

        [Required]
        public int ProcedimentoId { get; set; }  
    }
}
