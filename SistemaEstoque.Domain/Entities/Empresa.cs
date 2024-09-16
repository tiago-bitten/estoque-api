using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Empresa : IdentificadorBase
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public ETipoEmpresa TipoEmpresa { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int? ProprietarioId { get; set; }
        public Proprietario? Proprietario { get; set; }

        
        // Referencias para navegação
        public ConfiguracaoEstoque ConfiguracaoEstoque { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; } 
        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Insumo> Insumos { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
        public IEnumerable<EstoqueProduto> EstoquesProdutos { get; set; }
        public IEnumerable<EstoqueInsumo> EstoquesInsumos { get; set; }
        public IEnumerable<LoteProduto> LotesProdutos { get; set; }
        public IEnumerable<LoteInsumo> LotesInsumos { get; set; }
        public IEnumerable<MovimentacaoProduto> MovimentacoesProdutos { get; set; }
        public IEnumerable<MovimentacaoInsumo> MovimentacoesInsumos { get; set; }
        public IEnumerable<LogAlteracao> LogsAlteracoes { get; set; }
        public IEnumerable<HistoricoEstoque> HistoricosEstoquesProdutos { get; set; }
        public IEnumerable<HistoricoUsuarioAcesso?> HistoricosUsuariosAcessos { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<PerfilAcesso> PerfisAcessos { get; set; }
        public IEnumerable<PermissaoProduto> PermissoesProdutos { get; set; }
        public IEnumerable<PermissaoCategoria> PermissoesCategorias { get; set; }
        public IEnumerable<PermissaoInsumo> PermissoesInsumos { get; set; }
        
        public IEnumerable<RefreshToken> RefreshTokens { get; set; }
    }
}
