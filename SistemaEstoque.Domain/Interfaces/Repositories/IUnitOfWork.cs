﻿namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        Task RollbackAsync();

        ICategoriaRepository Categorias { get; }
        IUsuarioRepository Usuarios { get; }
        IProdutoRepository Produtos { get; }
        IInsumoRepository Insumos { get; }
        IFornecedorRepository Fornecedores { get; }
        IEstoqueProdutoRepository EstoquesProdutos { get; }
        ILoteProdutoRepository LotesProdutos { get; }
        ILoteInsumoRepository LoteInsumos { get; }
        IMovimentacaoProdutoRepository MovimentacoesProdutos { get; }
        IMovimentacaoInsumoRepository MovimentacoesInsumos { get; }
        ILogAlteracaoRepository LogsAlteracoes { get; }
    }
}