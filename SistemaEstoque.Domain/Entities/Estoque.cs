namespace SistemaEstoque.Domain.Entities
{
    public sealed class Estoque : EntidadeBase
    {
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
