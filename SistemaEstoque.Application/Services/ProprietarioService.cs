using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class ProprietarioService : ServiceBase<Proprietario>, IProprietarioService
    {
        public ProprietarioService(IProprietarioRepository repository)
            : base(repository)
        {
        }
    }
}
