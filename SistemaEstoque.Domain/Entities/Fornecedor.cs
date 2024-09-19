using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Fornecedor : IdentificadorTenant
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public ETipoItem Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public List<Lote> Lotes { get; set; } = new();
    }
}
