using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public abstract class HistoricoEstoque : IdentificadorTenant
    {
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
