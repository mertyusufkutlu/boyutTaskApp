using boyutTaskAppAPI.Applicaton.Services;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Queries.BasketItem;

public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, List<GetBasketItemsQueryResponse>>
{
    private readonly IBasketService _basketService;

    public GetBasketItemsQueryHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<List<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
    {
        var basketItems = await _basketService.GetBasketItemAsync(request.UserId);
        return basketItems.Select(ba => new GetBasketItemsQueryResponse()
        {
            BasketItemId = ba.Id,
            Name = ba.Product.Name,
            Price = ba.Product.Price,
            Quantity = ba.Quantity
        }).ToList();
    }
}