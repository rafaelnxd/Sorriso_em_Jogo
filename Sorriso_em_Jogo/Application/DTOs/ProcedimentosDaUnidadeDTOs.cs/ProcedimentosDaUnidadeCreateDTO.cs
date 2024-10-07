using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.DTOs.ProcedimentosDaUnidadeDTOs
{
    public class ProcedimentosDaUnidadeCreateDTO
    {
        [Required]
        public int UnidadeId { get; set; }  

        [Required]
        public int ProcedimentoId { get; set; }  
    }
}
