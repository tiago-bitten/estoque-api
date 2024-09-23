using SistemaEstoque.Application.DTOs.Items;

namespace SistemaEstoque.Application.UseCases.Items.CreateItem;

public interface ICreateItemUseCase
{
    Task<GetItemDto> ExecuteAsync(CreateItemDto dto);
}