using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class HistoricoEstoqueProduto : HistoricoEstoque
    {
        public int EstoqueProdutoId { get; set; }
        public EstoqueProduto EstoqueProduto { get; set; }
    }
}
