namespace Sorriso_em_Jogo.Application.DTOs.UsuarioDTOs
{
    public class UsuarioUpdateDTO
    {
        public int Id_usuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha {  get; set; } = string.Empty;
        public DateTime Data_cadastro { get; set; }
        public float? Pontos_recompensa { get; set; }
    }
}
