namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class LoteItem : EntidadeBase
    {
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioCompra { get; set; }
        public decimal PrecoUnitarioVenda { get; set; }
    }
}
