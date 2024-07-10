using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaEstoque.Application.Services
{
    public class LogAlteracaoService<T> : ILogAlteracaoService<T> where T : class
    {
        private readonly IUnitOfWork _uow;

        public LogAlteracaoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task LogAsync(object dadosAntigos, object dadosNovos, int itemId, int quantidade, int usuarioId, string tipo, int empresaId)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var log = new LogAlteracao
            {
                Tabela = typeof(T).Name,
                AlteradoEm = DateTime.Now,
                ItemId = itemId,
                Quantidade = quantidade,
                DadosAntigos = JsonSerializer.Serialize(dadosAntigos, options),
                DadosNovos = JsonSerializer.Serialize(dadosNovos, options),
                Tipo = tipo,
                UsuarioId = usuarioId,
                EmpresaId = empresaId
            };

            await _uow.LogsAlteracoes.LogAsync(log, empresaId);
            await _uow.CommitAsync();
        }
    }
}
