﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<RegistroAlteracaoEntidade> LogAlteracoes { get; set; }
        public DbSet<RegistroUsuarioAcesso> HistoricosUsuariosAcessos { get; set; }
        public DbSet<HistoricoEstoqueProduto> HistoricosEstoquesProdutos { get; set; }
        public DbSet<HistoricoEstoqueInsumo> HistoricosEstoquesInsumos { get; set; }
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
            modelBuilder.ApplyConfiguration(new LoteConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new InsumoConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new FornecedorConfig());
            modelBuilder.ApplyConfiguration(new EstoqueConfig());
            modelBuilder.ApplyConfiguration(new EstoqueInsumoConfig());
            modelBuilder.ApplyConfiguration(new LoteItemConfig());
            modelBuilder.ApplyConfiguration(new LoteInsumoConfig());
            modelBuilder.ApplyConfiguration(new MovimentacaoConfig());
            modelBuilder.ApplyConfiguration(new MovimentacaoInsumoConfig());
            modelBuilder.ApplyConfiguration(new RegistroAlteracaoEntidadeConfig());
            modelBuilder.ApplyConfiguration(new RegistroUsuarioAcessoConfig());
            modelBuilder.ApplyConfiguration(new HistoricoEstoqueConfig());
            modelBuilder.ApplyConfiguration(new HistoricoEstoqueInsumoConfig());
            modelBuilder.ApplyConfiguration(new PerfilAcessoConfig());
            modelBuilder.ApplyConfiguration(new ProprietarioConfig());
            modelBuilder.ApplyConfiguration(new PermissaoProdutoConfig());
            modelBuilder.ApplyConfiguration(new PermissaoCategoriaConfig());
            modelBuilder.ApplyConfiguration(new PermissaoInsumoConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
