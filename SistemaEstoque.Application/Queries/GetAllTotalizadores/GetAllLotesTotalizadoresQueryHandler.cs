using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllTotalizadores
{
    public class GetAllLotesTotalizadoresQueryHandler : IRequestHandler<GetAllLotesTotalizadoresQuery, GetAllLotesTotalizadoresResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllLotesTotalizadoresQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetAllLotesTotalizadoresResponse> Handle(GetAllLotesTotalizadoresQuery request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var lotesTotalizadoresDTO = await _uow.Lotes
                .GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(lote => new LoteTotalizadorDTO
                {
                    Id = lote.Id,
                    Descricao = lote.Descricao,
                    DataRecebimento = lote.DataRecebimento,
                    Total = lote.LotesProdutos.Sum(lp => lp.Quantidade) + lote.LotesInsumos.Sum(li => li.Quantidade),
                    Entradas = lote.LotesProdutos
                                .SelectMany(lp => lp.MovimentacoesProdutos)
                                .Where(mp => mp.Tipo == ETipoMovimentacao.Entrada && mp.Origem != EOrigemMovimentacao.CriacaoLote)
                                .Sum(mp => mp.Quantidade) + lote.LotesInsumos
                                .SelectMany(li => li.MovimentacoesInsumos)
                                .Where(mi => mi.Tipo == ETipoMovimentacao.Entrada && mi.Origem != EOrigemMovimentacao.CriacaoLote)
                                .Sum(mi => mi.Quantidade),
                    Saidas = lote.LotesProdutos
                                .SelectMany(lp => lp.MovimentacoesProdutos)
                                .Where(mp => mp.Tipo == ETipoMovimentacao.Saida)
                                .Sum(mp => mp.Quantidade) + lote.LotesInsumos
                                .SelectMany(li => li.MovimentacoesInsumos)
                                .Where(mi => mi.Tipo == ETipoMovimentacao.Saida)
                                .Sum(mi => mi.Quantidade)
                }).ToListAsync(cancellationToken);

            int total = await _uow.Lotes.GetAll(empresaId).CountAsync(cancellationToken);

            return new GetAllLotesTotalizadoresResponse(lotesTotalizadoresDTO, total);
        }
    }
}
