namespace Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs
{
    public class RegistroHabitoUpdateDTO
    {
        public int Id_habito { get; set; }
        public DateTime Data { get; set; }
        public string Imagem { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;

 
        public int UsuarioId { get; set; }
        public int HabitoId { get; set; }
    }
}
