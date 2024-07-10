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
        private readonly ILogAlteracaoService<Categoria> _logAlteracaoService;

        public UpdateCategoriaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICategoriaService categoriaService,
            ILogAlteracaoService<Categoria> logAlteracaoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoriaService = categoriaService;
            _logAlteracaoService = logAlteracaoService;
        }

        public async Task<UpdateCategoriaResponse> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
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

            await _logAlteracaoService.LogAsync(
                categoriaAntigaDTO,
                categoriaNovaDTO,
                categoriaNova.Id,
                totalAlteracoes,
                1,
                ETipoAlteracao.Alteracao,
                EMPRESA_CONSTANTE.ID_EMPRESA
            );

            _unitOfWork.Categorias.Update(categoriaNova);
            await _unitOfWork.CommitAsync();

            var response = _mapper.Map<UpdateCategoriaResponse>(categoriaNova);

            return response;
        }
    }
}
