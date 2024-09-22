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
        protected readonly SistemaEstoqueDbContext Context;
        protected readonly DbSet<T> DbSet;

        public RepositoryBase(SistemaEstoqueDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, params string[]? includes)
        {
            var query = DbSet.AsQueryable();
            query = query.ApplyIncludes(includes);
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<T?> GetAll(params string[]? includes)
        {
            var query = DbSet.AsQueryable();
            query = query.ApplyIncludes(includes);
            return query;
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            var query = DbSet.Where(predicate).AsQueryable();
            query = query.ApplyIncludes(includes);
            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T?> FindAll(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            var query = DbSet.Where(predicate).AsQueryable();
            query = query.ApplyIncludes(includes);
            return query;
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public void SoftRemove(T entity)
        {
            entity.Removido = true;
            DbSet.Update(entity);
        }

        public void SoftRemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                SoftRemove(entity);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
        {
            var query = DbSet.Where(predicate).AsQueryable();
            query = query.ApplyIncludes(includes);
            return await query.AnyAsync();
        }
    }
}
