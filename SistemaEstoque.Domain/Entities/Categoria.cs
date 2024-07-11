﻿using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public ETipoItem TipoItem { get; set; }

        public IEnumerable<Produto?> Produtos { get; set; }
        public IEnumerable<Insumo?> Insumos { get; set; }
    }
}