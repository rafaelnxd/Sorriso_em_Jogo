using Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs; // Importar o namespace correto

namespace Sorriso_em_Jogo.Application.DTOs.HabitoDTOs
{
    public class HabitoDTO
    {
        public int Id_habito { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public float Frequencia_ideal { get; set; }

        // Relacionamentos (lista de registros de hábitos associados)
        public List<Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs.RegistroHabitoDTO> RegistrosHabito { get; set; } = new List<Sorriso_em_Jogo.Application.DTOs.RegistroHabitoDTOs.RegistroHabitoDTO>();
    }
}

