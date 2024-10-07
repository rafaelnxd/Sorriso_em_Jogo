using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("Habito")]
    public class Habito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_habito { get; set; }

        [Required(ErrorMessage = "A descrição do hábito é obrigatória")]
        [StringLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de hábito é obrigatório")]
        [StringLength(50, ErrorMessage = "O tipo pode ter no máximo 50 caracteres")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A frequência ideal é obrigatória")]
        [Range(0, float.MaxValue, ErrorMessage = "A frequência ideal deve ser um número positivo")]
        public float Frequencia_ideal { get; set; }

        public List<RegistroHabito> RegistrosHabito { get; set; } = new List<RegistroHabito>();

        // Regras de Negócio

        // Valida a frequência ideal (embora já seja validada via Data Annotation)
        public void ValidarFrequenciaIdeal()
        {
            if (Frequencia_ideal <= 0)
            {
                throw new ArgumentException("A frequência ideal deve ser maior que zero.");
            }
        }

        // Verifica se a frequência ideal foi atingida
        public bool FrequenciaIdealAtingida()
        {
            return RegistrosHabito.Count >= Frequencia_ideal;
        }

        // Validação adicional da descrição 
        public void ValidarDescricaoUnica(string descricaoExistente = "")
        {
            if (!string.IsNullOrEmpty(descricaoExistente) && Descricao.Equals(descricaoExistente, System.StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Já existe um hábito com esta descrição.");
            }
        }
    }
}
