namespace SistemaEstoque.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal? PrecoVendaReferencia { get; set; }
        public decimal? PrecoCustoReferencia { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public IEnumerable<Estoque?> Estoques { get; set; }
        public IEnumerable<LoteProduto?> LotesProdutos { get; set; }
        public IEnumerable<MovimentacaoProduto?> MovimentacoesProdutos { get; set; }
    }
}
