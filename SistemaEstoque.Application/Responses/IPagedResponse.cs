using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Responses
{
    public interface IPagedResponse<T> where T : class
    {
        int Total { get; set; }
    }
}
