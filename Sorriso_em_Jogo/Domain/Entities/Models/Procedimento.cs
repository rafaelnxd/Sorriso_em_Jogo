using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("Procedimento")]
    public class Procedimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_procedimento { get; set; }

        [Required(ErrorMessage = "O nome do procedimento é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "A descrição pode ter no máximo 150 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        public List<ProcedimentosDaUnidade> ProcedimentosDaUnidade { get; set; } = new List<ProcedimentosDaUnidade>();

        // Regras de Negócio


        public void ValidarNome(string nomeExistente = "")
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new ArgumentException("O nome do procedimento é obrigatório e não pode ser vazio.");
            }


            if (!string.IsNullOrEmpty(nomeExistente) && Nome.Equals(nomeExistente, System.StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Já existe um procedimento com este nome.");
            }
        }

        // Verifica se o procedimento está associado a alguma unidade e impede exclusão
        public bool PodeExcluir()
        {
            if (ProcedimentosDaUnidade != null && ProcedimentosDaUnidade.Count > 0)
            {
                throw new InvalidOperationException("Este procedimento está associado a uma ou mais unidades e não pode ser excluído.");
            }

            return true;
        }


        // Valida a associação de procedimentos às unidades
        public bool ValidarAssociacaoUnidades()
        {
            return ProcedimentosDaUnidade != null && ProcedimentosDaUnidade.Count > 0;
        }
    }
}
