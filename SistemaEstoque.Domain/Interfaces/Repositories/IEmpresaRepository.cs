using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {
        Task AddAsync(Empresa empresa);
        Task<Empresa?> GetByIdAsync(int id);
        IQueryable<Empresa?> FindAll(Expression<Func<Empresa, bool>> predicate);
    }
}
