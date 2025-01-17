﻿using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Application.Commands.CreateCategoria
{
    public class CreateCategoriaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ETipoItem TipoItem { get; set; }
    }
}
