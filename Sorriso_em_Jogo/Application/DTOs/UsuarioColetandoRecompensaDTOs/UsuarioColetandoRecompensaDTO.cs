namespace Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs
{
    public class UsuarioColetandoRecompensaDTO
    {
        public int Id { get; set; } 
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty; 
        public int RecompensaId { get; set; }
        public string RecompensaDescricao { get; set; } = string.Empty; 
        public DateTime DataColeta { get; set; } 
    }
}
