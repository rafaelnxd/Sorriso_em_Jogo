namespace Sorriso_em_Jogo.Application.DTOs.FeedbackDTOs
{
    public class FeedbackDTO
    {
        public int Id_feedback { get; set; }

        public DateTime Data { get; set; }

        public string Comentario { get; set; } = string.Empty;

        // Detalhes do usuário que fez o feedback
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty; 
    }
}
