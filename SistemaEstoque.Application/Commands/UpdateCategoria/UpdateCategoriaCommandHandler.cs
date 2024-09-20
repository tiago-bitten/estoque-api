using AutoMapper;
using MediatR;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Application.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, UpdateCategoriaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;
        private readonly IRegistroAlteracaoEntidade<Categoria> _registroAlteracaoEntidade;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCategoriaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICategoriaService categoriaService,
            IRegistroAlteracaoEntidade<Categoria> registroAlteracaoEntidade, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoriaService = categoriaService;
            _registroAlteracaoEntidade = registroAlteracaoEntidade;
            _currentUserService = currentUserService;
        }

        public async Task<UpdateCategoriaResponse> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            if (!usuario.PerfilAcesso.PermissaoCategoria.Editar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para alterar categorias");
            
            int totalAlteracoes = 0;

            var categoriaNova = await _categoriaService.GetAndValidateEntityAsync(request.Id);

            var categoriaAntiga = categoriaNova.DeepClone();

            if (!string.IsNullOrEmpty(request.Nome))
            {
                categoriaNova.Nome = request.Nome;
                totalAlteracoes++;
            }

            if (!string.IsNullOrEmpty(request.Descricao))
            {
                categoriaNova.Descricao = request.Descricao;
                totalAlteracoes++;
            }

            var categoriaAntigaDTO = _mapper.Map<CategoriaDTO>(categoriaAntiga);
            var categoriaNovaDTO = _mapper.Map<CategoriaDTO>(categoriaNova);

            await _registroAlteracaoEntidade.LogAsync(
                categoriaAntigaDTO,
                categoriaNovaDTO,
                categoriaNova.Id,
                totalAlteracoes,
                usuario.Id,
                ETipoAlteracao.Alteracao,
                empresa.Id
            );

            _unitOfWork.Categorias.Update(categoriaNova);
            await _unitOfWork.CommitAsync();

            var response = _mapper.Map<UpdateCategoriaResponse>(categoriaNova);

            return response;
        }
    }
}
