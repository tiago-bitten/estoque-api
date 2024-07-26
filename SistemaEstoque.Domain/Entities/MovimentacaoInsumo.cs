using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class MovimentacaoInsumo : Movimentacao
    {
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public int EstoqueInsumoId { get; set; }
        public EstoqueInsumo EstoqueInsumo { get; set; }

        public int? LoteInsumoId { get; set; }
        public LoteInsumo? LoteInsumo { get; set; }
    }
}
