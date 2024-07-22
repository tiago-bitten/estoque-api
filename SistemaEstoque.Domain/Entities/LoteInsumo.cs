namespace SistemaEstoque.Domain.Entities
{
    public sealed class LoteInsumo : LoteItem
    {
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }
        public int LoteId { get; set; }
        public Lote Lote { get; set; }

        public IEnumerable<MovimentacaoInsumo> MovimentacoesInsumos { get; set; }
    }
}
