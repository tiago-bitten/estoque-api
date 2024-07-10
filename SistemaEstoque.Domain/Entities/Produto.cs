namespace SistemaEstoque.Domain.Entities
{
    public sealed class Produto : Item
    {   
        public IEnumerable<Estoque?> Estoques { get; set; }
        public IEnumerable<LoteProduto?> LotesProdutos { get; set; }
        public IEnumerable<MovimentacaoProduto?> MovimentacoesProdutos { get; set; }
    }
}
