namespace SistemaEstoque.Domain.Entities
{
    public class HistoricoEstoqueInsumo : HistoricoEstoque
    {
        public int EstoqueInsumoId { get; set; }
        public EstoqueInsumo EstoqueInsumo { get; set; }
    }
}
