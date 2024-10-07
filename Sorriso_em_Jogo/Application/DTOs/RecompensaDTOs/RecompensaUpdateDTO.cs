namespace Sorriso_em_Jogo.Application.DTOs.RecompensaDTOs
{
    public class RecompensaUpdateDTO
    {
        public int Id_recompensa { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public float Pontos_necessarios { get; set; }
    }
}
