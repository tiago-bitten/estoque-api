namespace SistemaEstoque.Domain.Entities
{
    public sealed class Produto : Item
    {   
        public IEnumerable<EstoqueProduto?> EstoquesProdutos { get; set; }
        public IEnumerable<LoteProduto?> LotesProdutos { get; set; }
        public IEnumerable<MovimentacaoProduto?> MovimentacoesProdutos { get; set; }
    }
}
