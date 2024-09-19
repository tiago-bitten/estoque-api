using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class RegistroAlteracaoEntidade : RegistroEntidade
    {
        public int Quantidade { get; set; }
        public string DadosAntigos { get; set; }
        public string DadosNovos { get; set; }
    }
}
