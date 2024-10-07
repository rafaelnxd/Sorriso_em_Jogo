namespace Sorriso_em_Jogo.Application.DTOs.HabitoDTOs
{
    public class HabitoUpdateDTO
    {
        public int Id_habito { get; set; }  
        public string Descricao { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public float Frequencia_ideal { get; set; }
    }
}
