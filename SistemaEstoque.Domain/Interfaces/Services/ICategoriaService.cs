using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        Task EnsureNotExistsByNameAsync(string nome);
    }
}
