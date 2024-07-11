using MediatR;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.Application.Commands.CreateInsumo
{
    public class CreateInsumoCommand : IRequest<CreateInsumoResponse>
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? PrecoCustoReferencia { get; set; }
        public decimal? PrecoVendaReferencia { get; set; }
        public int? CategoriaId { get; set; }
    }
}
