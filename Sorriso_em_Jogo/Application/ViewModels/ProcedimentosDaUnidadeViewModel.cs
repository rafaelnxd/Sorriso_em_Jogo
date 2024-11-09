using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class ProcedimentosDaUnidadeViewModel
    {
        [Required(ErrorMessage = "A Unidade é obrigatória")]
        public int UnidadeId { get; set; }
        public string UnidadeNome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Procedimento é obrigatório")]
        public int ProcedimentoId { get; set; }
        public string ProcedimentoNome { get; set; } = string.Empty;
    }
}
