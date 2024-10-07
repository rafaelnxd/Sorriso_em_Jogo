using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("ProcedimentosDaUnidade")]  
    public class ProcedimentosDaUnidade
    {
        [Key, Column(Order = 0)]  
        [ForeignKey("Unidade")]
        public int UnidadeId { get; set; }

        [Required]
        public Unidade Unidade { get; set; } = new Unidade();  

        [Key, Column(Order = 1)]  
        [ForeignKey("Procedimento")]
        public int ProcedimentoId { get; set; }

        [Required]
        public Procedimento Procedimento { get; set; } = new Procedimento();  
    }
}
