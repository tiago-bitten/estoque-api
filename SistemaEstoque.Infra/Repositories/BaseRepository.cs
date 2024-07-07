using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEstoque.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly SistemaEstoqueDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SistemaEstoqueDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, int empresaId)
        {
            return await _dbSet.SingleOrDefaultAsync(e =>
                EF.Property<int>(e, "Id") == id &&
                EF.Property<int>(e, "EmpresaId") == empresaId);
        }

        public async Task<IEnumerable<T>> GetAllAsync(int empresaId)
        {
            return await _dbSet.Where(e =>
                EF.Property<int>(e, "EmpresaId") == empresaId).ToListAsync();
        }

        public async Task AddAsync(T entity, int empresaId)
        {
            SetEmpresaId(entity, empresaId);
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, int empresaId)
        {
            foreach (var entity in entities)
            {
                SetEmpresaId(entity, empresaId);
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity, int empresaId)
        {
            SetEmpresaId(entity, empresaId);

            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property("EmpresaId").IsModified = false;
            _context.Entry(entity).Property("Removido").IsModified = false;
        }

        public void Remove(T entity, int empresaId)
        {
            SetEmpresaId(entity, empresaId);
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities, int empresaId)
        {
            foreach (var entity in entities)
            {
                SetEmpresaId(entity, empresaId);
            }
            _dbSet.RemoveRange(entities);
        }

        public async Task SoftRemoveAsync(T entity, int empresaId)
        {
            SetRemovido(entity, true);
            SetEmpresaId(entity, empresaId);
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public async Task SoftRemoveRangeAsync(IEnumerable<T> entities, int empresaId)
        {
            foreach (var entity in entities)
            {
                SetRemovido(entity, true);
                SetEmpresaId(entity, empresaId);
            }
            _dbSet.UpdateRange(entities);
            await Task.CompletedTask;
        }

        private void SetEmpresaId(T entity, int empresaId)
        {
            var propertyInfo = entity.GetType().GetProperty("EmpresaId");
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entity, empresaId);
            }
        }

        private void SetRemovido(T entity, bool removido)
        {
            var propertyInfo = entity.GetType().GetProperty("Removido");
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entity, removido);
            }
        }
    }
}
