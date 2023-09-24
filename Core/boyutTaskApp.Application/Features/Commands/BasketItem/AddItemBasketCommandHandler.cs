using boyutTaskAppAPI.Applicaton.Services;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;

public class AddItemBasketCommandHandler : IRequestHandler<CreateBasketItemRequest, CreateBasketItemResponse>
{
    private readonly IBasketService _basketService;

    public AddItemBasketCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<CreateBasketItemResponse> Handle(CreateBasketItemRequest request, CancellationToken cancellationToken)
    {
       var createdItem = await _basketService.AddItemToBasketAsync(request);
        return new CreateBasketItemResponse()
        {
            Quantity = createdItem.Quantity,
            BasketItemId = createdItem.BasketItemId,
            ProductId = createdItem.ProductId
        };
    }
}