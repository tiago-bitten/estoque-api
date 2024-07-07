using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }

        public async Task<Fornecedor?> GeyByCpfCnpj(string cpfCnpj)
        {
            return await _dbSet.FirstOrDefaultAsync(f => f.CpfCnpj == cpfCnpj);
        }
    }
}
