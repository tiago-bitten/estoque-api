using MediatR;

namespace SistemaEstoque.Application.Commands.CreateEstoque
{
    public class CreateEstoqueCommand : IRequest<CreateEstoqueResponse>
    {
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public int ProdutoId { get; set; }
    }
}
