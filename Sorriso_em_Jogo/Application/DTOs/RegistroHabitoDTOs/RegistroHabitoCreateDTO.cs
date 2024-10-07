namespace Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs
{
    public class RegistroHabitoCreateDTO
    {
        public DateTime Data { get; set; }
        public string Imagem { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;




        public int UsuarioId { get; set; }
        public int HabitoId { get; set; }
    }
}
