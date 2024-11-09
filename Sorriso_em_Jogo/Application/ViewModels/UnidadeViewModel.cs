using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class UnidadeViewModel
    {
        public int Id_unidade { get; set; }

        [Required(ErrorMessage = "O nome da unidade é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado da unidade é obrigatório")]
        [StringLength(100, ErrorMessage = "O estado pode ter no máximo 100 caracteres")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade da unidade é obrigatória")]
        [StringLength(100, ErrorMessage = "A cidade pode ter no máximo 100 caracteres")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço da unidade é obrigatório")]
        [StringLength(150, ErrorMessage = "O endereço pode ter no máximo 150 caracteres")]
        public string Endereco { get; set; } = string.Empty;
    }
}
