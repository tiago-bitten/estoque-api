using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static SistemaEstoque.Infra.Data.Constants;

namespace SistemaEstoque.Application.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, UpdateCategoriaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;

        public UpdateCategoriaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICategoriaService categoriaService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoriaService = categoriaService;
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

            await Console.Out.WriteLineAsync(
                $"Categoria antiga: {JsonSerializer.Serialize(categoriaAntiga)} " +
                $"Categoria nova: {JsonSerializer.Serialize(categoriaNova)}"
                );

            var logAlteracao = new LogAlteracao
            {
                Tabela = Tables.Categoria,
                ItemId = categoriaNova.Id,
                EmpresaId = EMPRESA_CONSTANTE.ID_EMPRESA,
                AlteradoEm = DateTime.Now,
                UsuarioId = 1,
                Quantidade = totalAlteracoes,
                Tipo = "ALTERACAO",
                DadosAntigos = JsonSerializer.Serialize(categoriaAntiga),
                DadosNovos = JsonSerializer.Serialize(categoriaNova)
            };

            _unitOfWork.Categorias.Update(categoriaNova);
            await _unitOfWork.LogsAlteracoes.LogAsync(logAlteracao, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _unitOfWork.CommitAsync();
        
            var response = _mapper.Map<UpdateCategoriaResponse>(categoriaNova);

            return await Task.FromResult(response);
        }
    }
}
