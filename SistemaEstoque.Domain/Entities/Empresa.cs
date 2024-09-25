using System.Runtime.CompilerServices;
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
        public bool AcessoBloqueado { get; set; }
        public int ProprietarioId { get; set; }
        
        public Proprietario Proprietario { get; set; }

        
        // Referencias para navegação
        public ConfiguracaoEstoque ConfiguracaoEstoque { get; set; }
        public List<Usuario> Usuarios { get; set; } = new();
        public List<Categoria> Categorias { get; set; } = new();
        public List<Item> Items { get; set; } = new();
        public List<Fornecedor> Fornecedores { get; set; } = new();
        public List<Estoque> Estoques { get; set; } = new();
        public List<Movimentacao> Movimentacoes { get; set; } = new();
        public List<AuditoriaEntidade> AuditoriaEntidades { get; set; } = new();
        public List<HistoricoEstoque> HistoricoEstoques { get; set; } = new();
        public List<RegistroUsuarioAcesso> HistoricosUsuariosAcessos { get; set; } = new();
        public List<RemessaLote> Lotes { get; set; } = new();
        public List<Lote> LoteItems { get; set; } = new();
        public List<PerfilAcesso> PerfisAcessos { get; set; } = new();
        public List<PermissaoProduto> PermissoesProdutos { get; set; } = new();
        public List<PermissaoCategoria> PermissoesCategorias { get; set; } = new();
        public List<PermissaoInsumo> PermissoesInsumos { get; set; } = new();
        public List<RefreshToken> RefreshTokens { get; set; } = new();

        #region Methods

        public void VerifyAcessoBloqueado()
        {
            if (AcessoBloqueado)
                throw new Exception("Acesso bloqueado, entre em contato com a gente para regularizar");
        }

        #endregion
    }
}