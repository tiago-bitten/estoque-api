using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository)
            : base(repository)
        {
        }

        public async Task EnsureNotExistsByNameAsync(string nome)
        {
            var exists = await Repository.AnyAsync(x => x.Nome == nome);

            if (exists)
                throw new Exception("ALTERAR");
        }
    }
}
