using MediatR;

namespace SistemaEstoque.Application.Commands.CreateEstoqueInsumo
{
    public class CreateEstoqueInsumoCommand : IRequest<CreateEstoqueInsumoResponse>
    {
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public int InsumoId { get; set; }
    }
}
