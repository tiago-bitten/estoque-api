using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Proprietario : IdentificadorTenant
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public List<Empresa> Empresas { get; set; } = new();
    }
}
