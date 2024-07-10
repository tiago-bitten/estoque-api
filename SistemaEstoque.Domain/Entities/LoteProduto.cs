namespace SistemaEstoque.Domain.Entities
{
    public sealed class LoteProduto : EntidadeBase
    {
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public MovimentacaoProduto MovimentacaoProduto { get; set; }
    }
}
