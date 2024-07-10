namespace SistemaEstoque.Domain.Entities
{
    public sealed class LoteProduto : Lote
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public MovimentacaoProduto MovimentacaoProduto { get; set; }
    }
}
