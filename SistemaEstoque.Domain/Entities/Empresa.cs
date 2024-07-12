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
        public IEnumerable<Insumo?> Insumos { get; set; }
        public IEnumerable<Fornecedor?> Fornecedores { get; set; }
        public IEnumerable<EstoqueProduto?> EstoquesProdutos { get; set; }
        public IEnumerable<EstoqueInsumo?> EstoquesInsumos { get; set; }
        public IEnumerable<LoteProduto?> LotesProdutos { get; set; }
        public IEnumerable<LoteInsumo?> LotesInsumos { get; set; }
        public IEnumerable<MovimentacaoProduto?> MovimentacoesProdutos { get; set; }
        public IEnumerable<MovimentoInsumo?> MovimentacoesInsumos { get; set; }
        public IEnumerable<LogAlteracao?> LogsAlteracoes { get; set; }
        public IEnumerable<HistoricoUsuarioAcesso?> HistoricosUsuariosAcessos { get; set; }
    }
}
