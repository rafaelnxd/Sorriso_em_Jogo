using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class ProcedimentoViewModel
    {
        public int Id_procedimento { get; set; }

        [Required(ErrorMessage = "O nome do procedimento é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "A descrição pode ter no máximo 150 caracteres")]
        public string Descricao { get; set; } = string.Empty;
    }
}
