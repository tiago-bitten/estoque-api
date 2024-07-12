﻿using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Repositories
{
    public class MovimentacaoProdutoRepository : IMovimentacaoProdutoRepository
    {
        private readonly IRepositoryBase<MovimentacaoProduto> _repositoryBase;

        public MovimentacaoProdutoRepository(IRepositoryBase<MovimentacaoProduto> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(MovimentacaoProduto movimentacao, int idEmpresa)
        {
            await _repositoryBase.AddAsync(movimentacao, idEmpresa);
        }

        public IQueryable<MovimentacaoProduto> GetAll(int idEmpresa)
        {
            return _repositoryBase.GetAll(idEmpresa);
        }

        public async Task<MovimentacaoProduto> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }
    }
}
