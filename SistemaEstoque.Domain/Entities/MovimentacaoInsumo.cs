namespace SistemaEstoque.Domain.Entities
{
    public sealed class MovimentoInsumo : Movimentacao
    {
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public int LoteInsumoId { get; set; }
        public LoteInsumo LoteInsumo { get; set; }
    }
}
