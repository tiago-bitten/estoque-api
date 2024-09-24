using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class AuditoriaEntidade : IdentificadorTenant
    {
        public string Tabela { get; set; }
        public int EntidadeId { get; set; }
        public DateTime Data { get; set; }
        public ETipoAlteracao Tipo { get; set; }
        public int UsuarioId { get; set; }
        public int? Quantidade { get; set; }
        public string? DadosAntigos { get; set; }
        public string? DadosNovos { get; set; }
        
        public Usuario Usuario { get; set; }
    }
}
