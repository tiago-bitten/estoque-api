using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public ETipoEmpresa TipoEmpresa { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public bool? Ativo { get; set; }

        public IEnumerable<Usuario?> Usuarios { get; set; }
        public IEnumerable<Categoria?> Categorias { get; set; } 
        public IEnumerable<Produto?> Produtos { get; set; }
        public IEnumerable<Fornecedor?> Fornecedores { get; set; }
        public IEnumerable<Estoque?> Estoques { get; set; }
        public IEnumerable<Lote?> Lotes { get; set; }
    }
}
