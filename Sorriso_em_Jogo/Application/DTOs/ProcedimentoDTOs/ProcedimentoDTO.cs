namespace Sorriso_em_Jogo.Application.DTOs.ProcedimentoDTOs
{
    public class ProcedimentoDTO
    {
        public int Id_procedimento { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        // Relacionamentos (se quiser expor os dados de ProcedimentosDaUnidade)
        public List<Sorriso_em_Jogo.Application.DTOs.ProcedimentosDaUnidadeDTOs.ProcedimentosDaUnidadeDTO> ProcedimentosDaUnidade { get; set; } = new List<Sorriso_em_Jogo.Application.DTOs.ProcedimentosDaUnidadeDTOs.ProcedimentosDaUnidadeDTO>();
    }
}
