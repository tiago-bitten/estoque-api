using SistemaEstoque.Application.DTOs.Items;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.UseCases.Items.CreateItem;

public class CreateItemUseCase : ICreateItemUseCase
{
    private readonly IUnitOfWork _uow;
    private readonly IItemService _itemService;

    public CreateItemUseCase(IUnitOfWork uow, IItemService itemService)
    {
        _uow = uow;
        _itemService = itemService;
    }

    public Task<GetItemDto> ExecuteAsync(CreateItemDto dto)
    {
    }
}