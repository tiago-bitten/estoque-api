namespace SistemaEstoque.Domain.Entities
{
    public sealed class Insumo : Item
    {
        public EstoqueInsumo? EstoqueInsumo { get; set; }
        public IEnumerable<LoteInsumo?> LotesInsumos { get; set; }
        public IEnumerable<MovimentacaoInsumo?> MovimentacoesInsumos { get; set; }
    }
}
