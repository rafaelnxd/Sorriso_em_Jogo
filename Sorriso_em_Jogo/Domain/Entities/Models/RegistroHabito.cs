using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sorriso_em_Jogo.Domain.Entities.Models;

[Table("RegistroHabito")]
public class RegistroHabito
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_habito { get; set; }

    [Required(ErrorMessage = "A data do registro é obrigatória")]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }

    [StringLength(255, ErrorMessage = "O link da imagem pode ter no máximo 255 caracteres")]
    public string Imagem { get; set; } = string.Empty;

    [StringLength(255, ErrorMessage = "As observações podem ter no máximo 255 caracteres")]
    public string Observacoes { get; set; } = string.Empty;

    [Required]
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; } = new Usuario();

    [Required]
    [ForeignKey("Habito")]
    public int HabitoId { get; set; }

    public Habito Habito { get; set; } = new Habito();

    // Regras de Negócio

    // Valida se a data do registro não é futura
    public void ValidarDataRegistro()
    {
        if (Data > DateTime.Now)
        {
            throw new InvalidOperationException("A data do registro não pode ser no futuro.");
        }
    }

    // Validação opcional: Se necessário, validar se a URL da imagem segue um formato específico
    public void ValidarImagem()
    {
        if (!string.IsNullOrEmpty(Imagem) && !Uri.IsWellFormedUriString(Imagem, UriKind.Absolute))
        {
            throw new InvalidOperationException("O link da imagem não está em um formato válido.");
        }
    }
}
