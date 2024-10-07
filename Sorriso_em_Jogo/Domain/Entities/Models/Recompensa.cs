using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("Recompensa")]
    public class Recompensa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_recompensa { get; set; }

        [Required(ErrorMessage = "A descrição da recompensa é obrigatória")]
        [StringLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Os pontos necessários são obrigatórios")]
        [Range(0, float.MaxValue, ErrorMessage = "Os pontos necessários devem ser maiores ou iguais a zero")]
        public float Pontos_necessarios { get; set; }

        public List<UsuarioColetandoRecompensa> UsuariosColetandoRecompensa { get; set; } = new List<UsuarioColetandoRecompensa>();

        // Regras de Negócio

        // Verifica se os pontos necessários são válidos
        public void ValidarPontosNecessarios()
        {
            if (Pontos_necessarios < 0)
            {
                throw new ArgumentException("Os pontos necessários não podem ser negativos.");
            }
        }

 
       
    }
}
