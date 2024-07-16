namespace SistemaEstoque.Domain.Entities
{
    public sealed class LoteProduto : LoteItem
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int LoteId { get; set; }
        public Lote Lote { get; set; }

        public MovimentacaoProduto MovimentacaoProduto { get; set; }
    }
}
