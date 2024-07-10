using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface ILogAlteracaoService<T> where T : class
    {
        Task LogAsync(object dadosAntigos, object dadosNovos, int itemId, int quantidade, int usuarioId, ETipoAlteracao tipo, int empresaId);
    }
}
