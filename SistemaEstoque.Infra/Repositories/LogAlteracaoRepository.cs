﻿using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.Infra.Repositories
{
    public class LogAlteracaoRepository : ILogAlteracaoRepository
    {
        private readonly IRepositoryBase<LogAlteracao> _repository;

        public LogAlteracaoRepository(IRepositoryBase<LogAlteracao> repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<LogAlteracao>> GetAllLogsFromItem(int itemId, string tabela, int empresaId)
        {
            return await _repository.FindAllAsync(x => x.ItemId == itemId && x.Tabela == tabela && x.EmpresaId == empresaId);
        }

        public async Task LogAsync(LogAlteracao log, int empresaId)
        {
            await _repository.AddAsync(log, empresaId);
        }
    }
}
