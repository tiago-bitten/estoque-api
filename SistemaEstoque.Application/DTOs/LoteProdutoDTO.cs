namespace SistemaEstoque.Application.DTOs
{
    public class LoteProdutoDTO
    {
        public int Id { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioCompra { get; set; }
        public decimal PrecoUnitarioVenda { get; set; }
        public ProdutoDTO Produto { get; set; }
    }
}
