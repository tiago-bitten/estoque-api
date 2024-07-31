using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }

        public override IQueryable<Usuario> GetAll(int empresaId)
        {
            return _dbSet
                .Include(u => u.PerfilAcesso).ThenInclude(p => p.PermissaoProduto)
                .Include(u => u.PerfilAcesso).ThenInclude(p => p.PermissaoCategoria)
                .Include(x => x.RefreshToken)
                .Where(u => u.EmpresaId == empresaId && u.Removido == false);
        }

        public override async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.PerfilAcesso).ThenInclude(p => p.PermissaoProduto)
                .Include(u => u.PerfilAcesso).ThenInclude(p => p.PermissaoCategoria)
                .Include(x => x.RefreshToken)
                .FirstOrDefaultAsync(u => u.Id == id);
        }   

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
