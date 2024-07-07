namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();

        Task RollbackAsync();

    }
}
