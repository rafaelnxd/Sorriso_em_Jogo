using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class RecompensaViewModel
    {
        public int Id_recompensa { get; set; }

        [Required(ErrorMessage = "A descrição da recompensa é obrigatória")]
        [StringLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Os pontos necessários são obrigatórios")]
        [Range(1, float.MaxValue, ErrorMessage = "Os pontos necessários devem ser maiores que zero")]
        public float Pontos_necessarios { get; set; }
    }
}
