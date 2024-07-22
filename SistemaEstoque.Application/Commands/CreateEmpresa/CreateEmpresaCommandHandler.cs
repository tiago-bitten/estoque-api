using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Localization;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateEmpresa
{
    public class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, CreateEmpresaResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProprietarioService _proprietarioService;

        public CreateEmpresaCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IProprietarioService proprietarioService)
        {
            _uow = uow;
            _mapper = mapper;
            _proprietarioService = proprietarioService;
        }

        public async Task<CreateEmpresaResponse> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var proprietario = await _proprietarioService.GetAndValidateEntityAsync(request.ProprietarioId);

            var empresa = _mapper.Map<Empresa>(request);

            empresa.Proprietario = proprietario;

            await _uow.Empresas.AddAsync(empresa);
            await _uow.CommitAsync();

            var perfilAcessoProprietario = new PerfilAcesso
            {
                Nome = "Proprietário",
            };

            var permissaoProduto = new PermissaoProduto
            {
                Visualizar = true,
                Editar = true,
                Criar = true,
                Excluir = true
            };

            var permissaoCategoria = new PermissaoCategoria
            {
                Visualizar = true,
                Editar = true,
                Criar = true,
                Excluir = true
            };

            perfilAcessoProprietario.PermissaoProduto = permissaoProduto;
            perfilAcessoProprietario.PermissaoCategoria = permissaoCategoria;

            await _uow.PerfisAcessos.AddAsync(perfilAcessoProprietario, empresa.Id);
            await _uow.PermissoesProdutos.AddAsync(permissaoProduto, empresa.Id);
            await _uow.PermissoesCategorias.AddAsync(permissaoCategoria, empresa.Id);

            var usuarioProprietario = new Usuario
            {
                Nome = proprietario.Nome,
                Email = proprietario.Email,
                Senha = "123456",
                PerfilAcesso = perfilAcessoProprietario,
                AcessoBloqueado = false,
                Removido = false,
            };

            await _uow.Usuarios.AddAsync(usuarioProprietario, empresa.Id);

            var configuracaoEstoque = new ConfiguracaoEstoque
            {
                PermiteEstoqueNegativo = false,
                PermitePassarEstoqueMinimo = false,
                PermitePassarEstoqueMaximo = false,
                PermiteEntradaSemLote = false,
                PermiteSaidaSemLote = false,
                NotificarEstoqueMaximo = true,
                NotificarEstoqueMinimo = true,
            };

            await _uow.ConfiguracoesEstoques.AddAsync(configuracaoEstoque, empresa.Id);

            await _uow.CommitAsync();

            var response = _mapper.Map<CreateEmpresaResponse>(empresa);

            return response;
        }
    }
}
