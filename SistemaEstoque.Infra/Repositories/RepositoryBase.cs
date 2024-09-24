using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using System.Linq.Expressions;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Infra.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : IdentificadorTenant
{
    #region Fields
    protected readonly SistemaEstoqueDbContext Context;
    protected readonly DbSet<T> DbSet;
    protected readonly IAmbienteUsuario AmbienteUsuario;
    #endregion

    #region Constructor
    public RepositoryBase(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
    {
        Context = context;
        AmbienteUsuario = ambienteUsuario;
        DbSet = context.Set<T>();
    }
    #endregion

    #region Methods
        
    #region GetByIdAsync
    public async Task<T?> GetByIdAsync(int id, params string[]? includes)
    {
        var query = DbSet.AsQueryable();
        query = query.ApplyIncludes(includes);
        query = query.GlobalWhere(AmbienteUsuario.GetTenantId());
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }
    #endregion

    #region GetAll
    public IQueryable<T?> GetAll(params string[]? includes)
    {
        var query = DbSet.AsQueryable();
        query = query.ApplyIncludes(includes);
        query = query.GlobalWhere(AmbienteUsuario.GetTenantId());
        return query;
    }
    #endregion

    #region FindAsync
    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
    {
        var query = DbSet.Where(predicate).AsQueryable();
        query = query.ApplyIncludes(includes);
        query = query.GlobalWhere(AmbienteUsuario.GetTenantId());
        return await query.FirstOrDefaultAsync();
    }
    #endregion

    #region FindAll
    public IQueryable<T?> FindAll(Expression<Func<T, bool>> predicate, params string[]? includes)
    {
        var query = DbSet.Where(predicate).AsQueryable();
        query = query.ApplyIncludes(includes);
        query = query.GlobalWhere(AmbienteUsuario.GetTenantId());
        return query;
    }
    #endregion

    #region AddAsync
    public async Task AddAsync(T entity)
    {
        entity.TenantId = AmbienteUsuario.GetTenantId();
        await DbSet.AddAsync(entity);
    }
    #endregion

    #region AddRangeAsync
    public async Task AddRangeAsync(List<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.TenantId = AmbienteUsuario.GetTenantId();
        }   
            
        await DbSet.AddRangeAsync(entities);
    }
    #endregion

    #region Update
    public void Update(T entity)
    {
        DbSet.Update(entity);
    }
    #endregion

    #region UpdateRange
    public void UpdateRange(List<T> entities)
    {
        DbSet.UpdateRange(entities);
    }
    #endregion

    #region Remove
    public void Remove(T entity)
    {
        DbSet.Remove(entity);
    }
    #endregion

    #region RemoveRange
    public void RemoveRange(List<T> entities)
    {
        DbSet.RemoveRange(entities);
    }
    #endregion

    #region SoftRemove
    public void SoftRemove(T entity)
    {
        entity.Removido = true;
        DbSet.Update(entity);
    }
    #endregion

    #region SoftRemoveRange
    public void SoftRemoveRange(List<T> entities)
    {
        foreach (var entity in entities)
        {
            SoftRemove(entity);
        }
    }
    #endregion

    #region AnyAsync
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, params string[]? includes)
    {
        var query = DbSet.Where(predicate).AsQueryable();
        query = query.ApplyIncludes(includes);
        query = query.GlobalWhere(AmbienteUsuario.GetTenantId());
        return await query.AnyAsync();
    }
    #endregion

    #endregion
}