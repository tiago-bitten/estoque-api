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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<LogAlteracao> LogAlteracoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new FornecedorConfig());
            modelBuilder.ApplyConfiguration(new EstoqueConfig());
            modelBuilder.ApplyConfiguration(new LoteConfig());
            modelBuilder.ApplyConfiguration(new MovimentacaoConfig());
            modelBuilder.ApplyConfiguration(new LogAlteracaoConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
