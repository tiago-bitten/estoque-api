using MediatR;

namespace SistemaEstoque.Application.Commands.CreateCategoria
{
    public class CreateCategoriaCommand : IRequest<CreateCategoriaResponse>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
