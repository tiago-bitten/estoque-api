using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> GetAndValidateEntityAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return entity ?? throw new Exception("Entidade não encontrada.");
        }
    }
}
