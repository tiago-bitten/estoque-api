using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using System.Linq.Expressions;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Infra.Extensions;

namespace SistemaEstoque.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : IdentificadorBase
    {
        protected readonly SistemaEstoqueDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(SistemaEstoqueDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, params string[]? includes)
        {
            var query = _dbSet.AsQueryable();
            query = query.ApplyIncludes(includes);
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<T?> GetAll(params string[]? includes)
        {
            var query = _dbSet.AsQueryable();
            query = query.ApplyIncludes(includes);
            return query;
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            var query = _dbSet.Where(predicate).AsQueryable();
            query = query.ApplyIncludes(includes);
            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T?> FindAll(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            var query = _dbSet.Where(predicate).AsQueryable();
            query = query.ApplyIncludes(includes);
            return query;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void SoftRemove(T entity)
        {
            entity.Removido = true;
            _dbSet.Update(entity);
        }

        public void SoftRemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                SoftRemove(entity);
            }
        }
    }
}
