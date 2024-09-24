using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
{
    #region Constructor
    public FornecedorRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
        : base(context, ambienteUsuario)
    {
    }
    #endregion
}