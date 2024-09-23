using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IRegistroAlteracaoEntidade
    {
        Task LogAsync(object dadosAntigos, object dadosNovos, int itemId, int quantidade, int usuarioId, ETipoAlteracao tipo, int empresaId);
    }
}
