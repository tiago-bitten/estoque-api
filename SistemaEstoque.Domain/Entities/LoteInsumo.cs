namespace SistemaEstoque.Domain.Entities
{
    public sealed class LoteInsumo : Lote
    {
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public MovimentacaoInsumo MovimentacaoInsumo { get; set; }
    }
}
