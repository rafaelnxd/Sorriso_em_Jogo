namespace Sorriso_em_Jogo.Application.DTOs.ProcedimentosDaUnidadeDTOs
{
    public class ProcedimentosDaUnidadeDTO
    {
        public int UnidadeId { get; set; }
        public string UnidadeNome { get; set; } = string.Empty;  

        public int ProcedimentoId { get; set; }
        public string ProcedimentoNome { get; set; } = string.Empty;  
    }
}
