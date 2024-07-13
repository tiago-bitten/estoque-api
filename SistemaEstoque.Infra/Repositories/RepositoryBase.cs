using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaEstoque.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly SistemaEstoqueDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(SistemaEstoqueDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
             
        }

        public virtual IQueryable<T> GetAll(int empresaId)
        {
            return _dbSet.Where(e =>
                EF.Property<int>(e, "EmpresaId") == empresaId)
                .Where(e => EF.Property<bool>(e, "Removido") == false)
                .AsQueryable();
        }

        public virtual async Task AddAsync(T entity, int empresaId)
        {
            var propertyInfo = entity.GetType().GetProperty("EmpresaId");
            propertyInfo.SetValue(entity, empresaId);
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).Property("EmpresaId").IsModified = false;
            _context.Entry(entity).Property("Removido").IsModified = false;

            _dbSet.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task SoftRemoveAsync(T entity)
        {
            var removidoProperty = entity.GetType().GetProperty("Removido");
            removidoProperty.SetValue(entity, true);
            
            _dbSet.Update(entity);
            
            await Task.CompletedTask;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
