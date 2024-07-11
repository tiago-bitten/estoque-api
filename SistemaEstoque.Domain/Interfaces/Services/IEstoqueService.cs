using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IEstoqueService<T> : IServiceBase<T> where T : Estoque
    {
        Task UpdateEstoque(T estoque, int quantidade, ETipoMovimentacao tipoMovimentacao);
    }
}
