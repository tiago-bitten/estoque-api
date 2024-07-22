﻿namespace SistemaEstoque.Domain.Entities
{
    public sealed class ConfiguracaoEstoque : EntidadeBase
    {
        public bool PermiteEstoqueNegativo { get; set; }
        public bool PermitePassarEstoqueMinimo { get; set; }
        public bool PermitePassarEstoqueMaximo { get; set; }
        public bool NotificarEstoqueMinimo { get; set; }
        public bool NotificarEstoqueMaximo { get; set; }
        public bool PermiteSaidaSemLote { get; set; }
        public bool PermiteEntradaSemLote { get; set; }
    }
}
