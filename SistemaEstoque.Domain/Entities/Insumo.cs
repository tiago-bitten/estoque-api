namespace SistemaEstoque.Domain.Entities
{
    public sealed class Insumo : Item
    {
        public IEnumerable<LoteInsumo?> LotesInsumo { get; set; }
        public IEnumerable<MovimentacaoInsumo?> MovimentacoesInsumo { get; set; }
    }
}
