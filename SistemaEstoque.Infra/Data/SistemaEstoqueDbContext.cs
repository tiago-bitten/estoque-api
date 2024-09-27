using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Infra.EntitiesConfig;

namespace SistemaEstoque.Infra.Data
{
    public class SistemaEstoqueDbContext : DbContext
    {
        public SistemaEstoqueDbContext(DbContextOptions<SistemaEstoqueDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ConfiguracaoEstoque> ConfiguracoesEstoques { get; set; }
        public DbSet<RemessaLote> Lotes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lote> LoteItems { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<HistoricoEstoque> HistoricoEstoques { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<AuditoriaEntidade> LogAlteracoes { get; set; }
        public DbSet<AuditoriaUsuarioAcesso> HistoricosUsuariosAcessos { get; set; }
        public DbSet<PerfilAcesso> PerfisAcessos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<PermissaoProduto> PermissoesProdutos { get; set; }
        public DbSet<PermissaoCategoria> PermissoesCategorias { get; set; }
        public DbSet<PermissaoInsumo> PermissoesInsumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfig());
            modelBuilder.ApplyConfiguration(new ConfiguracaoEstoqueConfig());
            modelBuilder.ApplyConfiguration(new RemessaLoteConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new FornecedorConfig());
            modelBuilder.ApplyConfiguration(new EstoqueConfig());
            modelBuilder.ApplyConfiguration(new LoteConfig());
            modelBuilder.ApplyConfiguration(new MovimentacaoConfig());
            modelBuilder.ApplyConfiguration(new AuditoriaEntidadeConfig());
            modelBuilder.ApplyConfiguration(new RegistroUsuarioAcessoConfig());
            modelBuilder.ApplyConfiguration(new HistoricoEstoqueConfig());
            modelBuilder.ApplyConfiguration(new PerfilAcessoConfig());
            modelBuilder.ApplyConfiguration(new ProprietarioConfig());
            modelBuilder.ApplyConfiguration(new PermissaoProdutoConfig());
            modelBuilder.ApplyConfiguration(new PermissaoCategoriaConfig());
            modelBuilder.ApplyConfiguration(new PermissaoInsumoConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
