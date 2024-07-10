namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface ILogAlteracaoService<T> where T : class
    {
        Task LogAsync(T dadosAntigos, T dadosNovos, int itemId, int quantidade, int usuarioId, string tipo, int empresaId);
    }
}
