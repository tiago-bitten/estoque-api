namespace SistemaEstoque.Domain.Entities
{
    public sealed class Insumo : Item
    {
        public IEnumerable<LoteInsumo?> LotesInsumo { get; set; }
        public IEnumerable<MovimentacaoInsumo?> MovimentacoesInsumos { get; set; }
        public IEnumerable<EstoqueInsumo?> EstoquesInsumos { get;}
    }
}
