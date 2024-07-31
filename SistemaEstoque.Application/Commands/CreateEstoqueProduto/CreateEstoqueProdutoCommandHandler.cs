﻿using AutoMapper;
using MediatR;
using SistemaEstoque.Application.Commands.CreateEstoque;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateEstoqueProduto
{
    public class CreateEstoqueProdutoCommandHandler : IRequestHandler<CreateEstoqueProdutoCommand, CreateEstoqueProdutoResponse>
    {
        private readonly IUnitOfWork _ouw;
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;
        private readonly ICurrentUserService _currentUserService;

        public CreateEstoqueProdutoCommandHandler(
            IUnitOfWork ouw, 
            IMapper mapper,
            IProdutoService produtoService, ICurrentUserService currentUserService)
        {
            _ouw = ouw;
            _mapper = mapper;
            _produtoService = produtoService;
            _currentUserService = currentUserService;
        }

        public async Task<CreateEstoqueProdutoResponse> Handle(CreateEstoqueProdutoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            var produto = await _produtoService.GetAndValidateEntityAsync(request.ProdutoId);

            if (request.QuantidadeMinima <= 0 || request.QuantidadeMaxima <= 0)
                throw new Exception("Quantidade minima e maxima devem ser maiores que 0");

            if (request.QuantidadeMinima > request.QuantidadeMaxima)
                throw new Exception("Quantidade minima deve ser menor que a quantidade maxima");

            var existsEstoque = await _ouw.EstoquesProdutos.FindAsync(e => e.ProdutoId == request.ProdutoId && e.Removido == false);
            if (existsEstoque != null)
                throw new Exception($"Estoque para {existsEstoque.Produto.Nome} já foi cadastrado");

            var estoque = _mapper.Map<EstoqueProduto>(request);

            estoque.Produto = produto;
            estoque.Empresa = empresa;

            await _ouw.EstoquesProdutos.AddAsync(estoque, empresa.Id);
            await _ouw.CommitAsync();
        
            var response = _mapper.Map<CreateEstoqueProdutoResponse>(estoque);

            return await Task.FromResult(response);
        }
    }
}
