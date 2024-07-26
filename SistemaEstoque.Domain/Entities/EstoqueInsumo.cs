using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class EstoqueInsumo : Estoque
    {
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public IEnumerable<HistoricoEstoqueInsumo?> HistoricosEstoquesInsumos { get; set; }
        public IEnumerable<MovimentacaoInsumo?> MovimentacoesInsumos { get; set; }
    }
}
