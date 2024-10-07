namespace Sorriso_em_Jogo.Application.DTOs.RecompensaDTOs
{
    public class RecompensaDTO
    {
        public int Id_recompensa { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public float Pontos_necessarios { get; set; }

        
        public List<Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs.UsuarioColetandoRecompensaDTO> UsuariosColetandoRecompensa { get; set; } = new List<Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs.UsuarioColetandoRecompensaDTO>();
    }
}
