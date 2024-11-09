using System;
using System.ComponentModel.DataAnnotations;

namespace Sorriso_em_Jogo.Application.ViewModels
{
    public class UsuarioColetandoRecompensaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório")]
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A recompensa é obrigatória")]
        public int RecompensaId { get; set; }
        public string RecompensaDescricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data da coleta é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataColeta { get; set; }
    }
}
