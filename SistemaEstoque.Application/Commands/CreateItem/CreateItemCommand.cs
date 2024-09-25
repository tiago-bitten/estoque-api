using MediatR;
using SistemaEstoque.Application.Commands.CreateProduto;

namespace SistemaEstoque.Application.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<CreateItemResponse>
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? PrecoVendaReferencia { get; set; }
        public decimal? PrecoCustoReferencia { get; set; }
        public int CategoriaId { get; set; }
    }
}
