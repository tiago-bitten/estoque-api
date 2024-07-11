using MediatR;

namespace SistemaEstoque.Application.Commands.CreateEstoque
{
    public class CreateEstoqueProdutoCommand : IRequest<CreateEstoqueProdutoResponse>
    {
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public int ProdutoId { get; set; }
    }
}
