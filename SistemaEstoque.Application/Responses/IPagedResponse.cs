using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Responses
{
    public interface IPagedResponse
    {
        int Total { get; set; }
    }
}
