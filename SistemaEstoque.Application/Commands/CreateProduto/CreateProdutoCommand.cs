using MediatR;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Commands.CreateProduto
{
    public class CreateProdutoCommand : IRequest<CreateProdutoResponse>
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal? PrecoCusto { get; set; }
        public int CategoriaId { get; set; }
    }
}
