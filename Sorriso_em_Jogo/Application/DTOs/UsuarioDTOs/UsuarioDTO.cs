using Sorriso_em_Jogo.Application.DTOs.FeedbackDTOs;
using Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs;
using Sorriso_em_Jogo.Application.DTOs.UsuarioColetandoRecompensaDTOs;

namespace Sorriso_em_Jogo.Application.DTOs.UsuarioDTOs
{
    

    public class UsuarioDTO
    {
        public int Id_usuario { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime Data_cadastro { get; set; }

        public float? Pontos_recompensa { get; set; }



    
        public List<FeedbackDTO>? Feedbacks { get; set; }
        public List<RegistroHabitoDTO>? RegistrosHabito { get; set; }
        public List<UsuarioColetandoRecompensaDTO>? RecompensasColetadas { get; set; }
    }

}
