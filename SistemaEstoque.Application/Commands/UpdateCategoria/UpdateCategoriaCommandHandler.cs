﻿using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using System.Text.Json;
using static SistemaEstoque.Infra.Data.Constants;

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

            var categoriaAntiga = new Categoria
            {
                Id = categoriaNova.Id,
                Nome = categoriaNova.Nome,
                Descricao = categoriaNova.Descricao,
                EmpresaId = categoriaNova.EmpresaId,
                Removido = categoriaNova.Removido,
                Produtos = categoriaNova.Produtos
            };

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

            await _logAlteracaoService.LogAsync(
                categoriaAntiga,
                categoriaNova,
                categoriaNova.Id,
                totalAlteracoes,
                1,
                "ALTERACAO",
                EMPRESA_CONSTANTE.ID_EMPRESA
            );

            _unitOfWork.Categorias.Update(categoriaNova);
            await _unitOfWork.CommitAsync();

            var response = _mapper.Map<UpdateCategoriaResponse>(categoriaNova);

            return response;
        }
    }
}
