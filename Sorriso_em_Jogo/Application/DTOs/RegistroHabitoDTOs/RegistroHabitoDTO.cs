namespace Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs
{
    public class RegistroHabitoDTO
    {
        public int Id_habito { get; set; }
        public DateTime Data { get; set; }
        public string Imagem { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;

        // Informações básicas sobre o usuário e o hábito relacionado ao registro
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;
        public int HabitoId { get; set; }
        public string HabitoDescricao { get; set; } = string.Empty;
    }
}
