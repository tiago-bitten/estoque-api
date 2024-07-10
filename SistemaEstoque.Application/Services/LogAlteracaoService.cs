using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using System.Text.Json;

namespace SistemaEstoque.Application.Services
{
    public class LogAlteracaoService<T> : ILogAlteracaoService<T> where T : class
    {
        private readonly IUnitOfWork _uow;

        public LogAlteracaoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task LogAsync(T dadosAntigos, T dadosNovos, int itemId, int quantidade, int usuarioId, string tipo, int empresaId)
        {
            var log = new LogAlteracao
            {
                Tabela = typeof(T).Name,
                AlteradoEm = DateTime.Now,
                ItemId = itemId,
                Quantidade = quantidade,
                DadosAntigos = JsonSerializer.Serialize(dadosAntigos),
                DadosNovos = JsonSerializer.Serialize(dadosNovos),
                Tipo = tipo,
                UsuarioId = usuarioId,
                EmpresaId = empresaId
            };

            await _uow.LogsAlteracoes.LogAsync(log, empresaId);
            await _uow.CommitAsync();
        }
    }
}
