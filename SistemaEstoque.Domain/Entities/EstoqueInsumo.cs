namespace SistemaEstoque.Domain.Entities
{
    public sealed class EstoqueInsumo : Estoque
    {
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }
    }
}
