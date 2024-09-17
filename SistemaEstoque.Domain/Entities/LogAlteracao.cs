using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class LogAlteracao : IdentificadorTenant
    {
        public string Tabela { get; set; }
        public DateTime AlteradoEm { get; set; }
        public int ItemId { get; set; }
        public int Quantidade { get; set; }
        public string DadosAntigos { get; set; }
        public string DadosNovos { get; set; }
        public ETipoAlteracao Tipo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
