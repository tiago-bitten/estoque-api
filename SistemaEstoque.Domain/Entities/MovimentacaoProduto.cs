using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class MovimentacaoProduto : Movimentacao
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int EstoqueProdutoId { get; set; }
        public EstoqueProduto EstoqueProduto { get; set; }

        public int? LoteProdutoId { get; set; }
        public LoteProduto? LoteProduto { get; set; }
    }
}
