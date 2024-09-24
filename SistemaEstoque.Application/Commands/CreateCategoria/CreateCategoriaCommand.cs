using MediatR;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Application.Commands.CreateCategoria
{
    public class CreateCategoriaCommand : IRequest<CreateCategoriaResponse>
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public ETipoItem TipoItem { get; set; }
    }
}
