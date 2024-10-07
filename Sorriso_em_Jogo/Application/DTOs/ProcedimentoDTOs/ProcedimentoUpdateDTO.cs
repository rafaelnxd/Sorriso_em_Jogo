namespace Sorriso_em_Jogo.Application.DTOs.ProcedimentoDTOs
{
    public class ProcedimentoUpdateDTO
    {
        public int Id_procedimento { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
