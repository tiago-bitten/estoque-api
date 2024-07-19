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
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<MovimentacaoInsumo> Insumos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<EstoqueProduto> EstoquesProdutos { get; set; }
        public DbSet<EstoqueInsumo> EstoquesInsumos { get; set; }
        public DbSet<LoteProduto> LotesProdutos { get; set; }
        public DbSet<LoteInsumo> LotesInsumos { get; set; }
        public DbSet<MovimentacaoProduto> MovimentacoesProdutos { get; set; }
        public DbSet<MovimentacaoInsumo> MovimentacoesInsumos { get; set; }
        public DbSet<LogAlteracao> LogAlteracoes { get; set; }
        public DbSet<HistoricoUsuarioAcesso> HistoricosUsuariosAcessos { get; set; }
        public DbSet<HistoricoEstoqueProduto> HistoricosEstoquesProdutos { get; set; }
        public DbSet<HistoricoEstoqueInsumo> HistoricosEstoquesInsumos { get; set; }
        public DbSet<PerfilAcesso> PerfisAcessos { get; set; }
        public DbSet<PermissaoProduto> PermissoesProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
            modelBuilder.ApplyConfiguration(new LoteConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new InsumoConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new FornecedorConfig());
            modelBuilder.ApplyConfiguration(new EstoqueProdutoConfig());
            modelBuilder.ApplyConfiguration(new EstoqueInsumoConfig());
            modelBuilder.ApplyConfiguration(new LoteProdutoConfig());
            modelBuilder.ApplyConfiguration(new LoteInsumoConfig());
            modelBuilder.ApplyConfiguration(new MovimentacaoProdutoConfig());
            modelBuilder.ApplyConfiguration(new MovimentacaoInsumoConfig());
            modelBuilder.ApplyConfiguration(new LogAlteracaoConfig());
            modelBuilder.ApplyConfiguration(new HistoricoUsuarioAcessoConfig());
            modelBuilder.ApplyConfiguration(new HistoricoEstoqueProdutoConfig());
            modelBuilder.ApplyConfiguration(new HistoricoEstoqueInsumoConfig());
            modelBuilder.ApplyConfiguration(new PerfilAcessoConfig());
            modelBuilder.ApplyConfiguration(new PermissaoProdutoConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
