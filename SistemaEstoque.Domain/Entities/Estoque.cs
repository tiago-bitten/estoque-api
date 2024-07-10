namespace SistemaEstoque.Domain.Entities
{
    public abstract class Estoque : EntidadeBase
    {
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
    }
}
