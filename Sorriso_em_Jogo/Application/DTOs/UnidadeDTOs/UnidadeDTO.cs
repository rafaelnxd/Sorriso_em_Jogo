﻿namespace Sorriso_em_Jogo.Application.DTOs.UnidadeDTOs
{
    public class UnidadeDTO
    {
        public int Id_unidade { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }
}