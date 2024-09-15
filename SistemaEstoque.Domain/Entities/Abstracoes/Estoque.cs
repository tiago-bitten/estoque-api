namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class Estoque : IdentificadorBase
    {
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }

        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverQuantidade(int quantidade)
        {
            Quantidade -= quantidade;
        }
    }
}
