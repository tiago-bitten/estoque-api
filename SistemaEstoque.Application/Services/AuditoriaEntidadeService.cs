using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using System.Text.Json;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Application.Services
{
    public class AuditoriaEntidadeService : IAuditoriaEntidadeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuditoriaEntidadeRepository _auditoriaEntidadeRepository;
        private readonly IAmbienteUsuario _ambienteUsuario;

        public AuditoriaEntidadeService(IUnitOfWork uow, IAuditoriaEntidadeRepository auditoriaEntidadeRepository, IAmbienteUsuario ambienteUsuario)
        {
            _uow = uow;
            _auditoriaEntidadeRepository = auditoriaEntidadeRepository;
            _ambienteUsuario = ambienteUsuario;
        }

        public async Task AuditarAdicaoAsync<T>(T entidade, string tabela) where T : IdentificadorBase
        {
            var adicao = new AuditoriaEntidade
            {
                Tabela = tabela,
                Data = DateTime.Now,
                EntidadeId = entidade.Id,
                DadosAntigos = null,
                DadosNovos = JsonSerializer.Serialize(entidade),
                Quantidade = null,
                UsuarioId = _ambienteUsuario.GetUsuarioId()
            };

            await _auditoriaEntidadeRepository.AddAsync(adicao);
        }

        public async Task LogAsync(string? dadosAntigos, string? dadosNovos, string tabela, int entidadeId, int quantidade, int usuarioId, ETipoAlteracao tipo)
        {
            var log = new AuditoriaEntidade
            {
                Tabela = tabela,
                Data = DateTime.Now,
                EntidadeId = entidadeId,
                Quantidade = quantidade,
                DadosAntigos = dadosAntigos ?? JsonSerializer.Serialize(dadosAntigos),
                DadosNovos = dadosNovos ?? JsonSerializer.Serialize(dadosNovos),
                Tipo = tipo,
                UsuarioId = usuarioId,
            };

            await _auditoriaEntidadeRepository.AddAsync(log);
            await _uow.CommitAsync();
        }
    }
}
