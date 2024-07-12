﻿namespace SistemaEstoque.Domain.Entities
{
    public class HistoricoUsuarioAcesso : EntidadeBase
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime DataAcesso { get; set; }
        public string IpAcesso { get; set; }
        public string UserAgent { get; set; }
        public bool AcessoValido { get; set; }
    }
}