﻿using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.Infra.Repositories
{
    public class RegistroAlteracaoEntidadeEntidadeRepository : IRegistroAlteracaoEntidadeRepository
    {
        private readonly IRepositoryBase<RegistroAlteracaoEntidade> _repository;

        public RegistroAlteracaoEntidadeEntidadeRepository(IRepositoryBase<RegistroAlteracaoEntidade> repository)
        {
            _repository = repository;
        }

        public IQueryable<RegistroAlteracaoEntidade> GetAllLogsFromItem(int itemId, string tabela, int empresaId)
        {
            return _repository.FindAll(x => x.ItemId == itemId && x.Tabela == tabela && x.TenantId == empresaId);
        }

        public async Task LogAsync(RegistroAlteracaoEntidade registro, int empresaId)
        {
            await _repository.AddAsync(registro, empresaId);
        }
    }
}