using SistemaEstoque.Domain.Enterprise.Exceptions;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : IdentificadorBase
    {
        protected readonly IRepositoryBase<T> Repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            Repository = repository;
        }

        public async Task<bool> ExistsAsync(int id, bool includeDeleted = false)
        {
            return await Repository
                .AnyAsync(x => x.Id == id && x.Removido == includeDeleted);            
        }

        public async Task EnsureExistsAsync(int id, bool includeDeleted = false)
        {
            await GetAndEnsureExistsAsync(id, includeDeleted);
        }

        public async Task<T> GetAndEnsureExistsAsync(int id, bool includeDeleted = false, params string[]? includes)
        {
            var entity = await Repository.GetByIdAsync(id, includes);
            
            if (entity is null)
                throw new EntityNotFoundException<T>(id);

            return entity;
        }
    }
}
