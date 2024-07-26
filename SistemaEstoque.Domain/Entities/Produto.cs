using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Produto : Item
    {   
        public EstoqueProduto? EstoqueProduto { get; set; }
        public IEnumerable<LoteProduto?> LotesProdutos { get; set; }
        public IEnumerable<MovimentacaoProduto?> MovimentacoesProdutos { get; set; }
    }
}
