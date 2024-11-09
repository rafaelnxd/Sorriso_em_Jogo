using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class HabitoViewModel
    {
        public int Id_habito { get; set; }

        [Required(ErrorMessage = "A descrição do hábito é obrigatória")]
        [StringLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de hábito é obrigatório")]
        [StringLength(50, ErrorMessage = "O tipo pode ter no máximo 50 caracteres")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A frequência ideal é obrigatória")]
        [Range(1, float.MaxValue, ErrorMessage = "A frequência ideal deve ser um número positivo maior que zero")]
        public float Frequencia_ideal { get; set; }
    }
}
