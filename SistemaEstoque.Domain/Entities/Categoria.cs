﻿using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Categoria : IdentificadorTenant
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public ETipoItem TipoItem { get; set; }

        
        // Referencias para navegação
        public List<Item> Items { get; set; } = new();
    }
}
