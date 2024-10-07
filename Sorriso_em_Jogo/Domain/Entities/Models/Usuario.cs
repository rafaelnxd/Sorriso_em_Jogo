using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sorriso_em_Jogo.Domain.Entities.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email não está em um formato válido")]
        [StringLength(100, ErrorMessage = "O email pode ter no máximo 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, ErrorMessage = "A senha pode ter no máximo 100 caracteres")]
        public string Senha { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data_cadastro { get; set; }

        [Column("Pontos_recompensa")]
        public float? Pontos_recompensa { get; private set; } = 0;  

        // Relacionamentos
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public List<RegistroHabito> RegistrosHabito { get; set; } = new List<RegistroHabito>();
        public List<UsuarioColetandoRecompensa> RecompensasColetadas { get; set; } = new List<UsuarioColetandoRecompensa>();

        // Método para acumular pontos de recompensa
        public void AcumularPontos(float pontos)
        {
            if (pontos < 0)
                throw new ArgumentException("Os pontos acumulados devem ser positivos.");

            Pontos_recompensa += pontos;
        }

        // Método para verificar se o usuário pode resgatar uma recompensa
        public bool PodeResgatarRecompensa(Recompensa recompensa)
        {
            return Pontos_recompensa >= recompensa.Pontos_necessarios;
        }

        // Método para resgatar uma recompensa
        public void ResgatarRecompensa(Recompensa recompensa)
        {
            if (PodeResgatarRecompensa(recompensa))
            {
                Pontos_recompensa -= recompensa.Pontos_necessarios;

                // Registra a coleta da recompensa
                RecompensasColetadas.Add(new UsuarioColetandoRecompensa
                {
                    UsuarioId = Id_usuario,
                    RecompensaId = recompensa.Id_recompensa,
                    DataColeta = DateTime.Now
                });
            }
            else
            {
                throw new InvalidOperationException("Pontos insuficientes para resgatar a recompensa.");
            }
        }
    }
}
