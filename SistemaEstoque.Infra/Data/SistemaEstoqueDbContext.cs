using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
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
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
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
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
