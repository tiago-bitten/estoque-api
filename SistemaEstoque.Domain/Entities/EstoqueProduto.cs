namespace SistemaEstoque.Domain.Entities
{
    public sealed class EstoqueProduto : Estoque
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
