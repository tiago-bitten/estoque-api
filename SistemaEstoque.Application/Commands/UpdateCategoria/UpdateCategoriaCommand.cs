using MediatR;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Application.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommand : IRequest<UpdateCategoriaResponse>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ETipoItem? TipoItem { get; set; }
    }
}
