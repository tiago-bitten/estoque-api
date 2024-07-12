using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public class HistoricoEstoqueProduto : HistoricoEstoque
    {
        public int EstoqueProdutoId { get; set; }
        public EstoqueProduto EstoqueProduto { get; set; }
    }
}
