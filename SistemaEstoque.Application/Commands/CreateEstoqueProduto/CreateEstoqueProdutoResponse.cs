﻿namespace SistemaEstoque.Application.Commands.CreateEstoque
{
    public class CreateEstoqueProdutoResponse
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public int ProdutoId { get; set; }
    }
}
