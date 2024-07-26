using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class HistoricoEstoqueInsumo : HistoricoEstoque
    {
        public int EstoqueInsumoId { get; set; }
        public EstoqueInsumo EstoqueInsumo { get; set; }
    }
}
