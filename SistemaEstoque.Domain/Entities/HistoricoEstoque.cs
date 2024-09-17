using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class HistoricoEstoque : IdentificadorTenant
    {
        public ETipoItem Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
