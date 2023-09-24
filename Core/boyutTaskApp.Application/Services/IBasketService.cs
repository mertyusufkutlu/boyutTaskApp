using boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;
using boyutTaskAppAPI.Domain.Entities;

namespace boyutTaskAppAPI.Applicaton.Services;

public interface IBasketService
{
    public Task<List<BasketItem>> GetBasketItemAsync(Guid userId);
    public Task<CreateBasketItemResponse> AddItemToBasketAsync(CreateBasketItemRequest createBasketItemRequest);
    public Task<bool> UpdateQuantityAsync(UpdateBasketItemRequest updateBasketItemRequest);
    public Task<bool> RemoveBasketItemAsync(Guid basketId);
}