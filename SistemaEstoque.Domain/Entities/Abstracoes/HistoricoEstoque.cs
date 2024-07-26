namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class HistoricoEstoque : EntidadeBase
    {
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
