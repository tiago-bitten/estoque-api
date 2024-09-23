using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaEstoque.Application.Services
{
    public class RegistroAlteracaoEntidade<T> : IRegistroAlteracaoEntidade<T> where T : class
    {
        private readonly IUnitOfWork _uow;

        public RegistroAlteracaoEntidade(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task LogAsync(object dadosAntigos, object dadosNovos, int itemId, int quantidade, int usuarioId, ETipoAlteracao tipo, int empresaId)
        {
            var log = new RegistroAlteracaoEntidade
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

            await _uow.RegistrosAlteracoes.LogAsync(log, empresaId);
            await _uow.CommitAsync();
        }
    }
}
