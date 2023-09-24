using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Services;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;

public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommandRequest,bool>
{
    private readonly IBasketService _basketService;

    public RemoveBasketItemCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<bool> Handle(RemoveBasketItemCommandRequest request, CancellationToken cancellationToken)
    {
        var isDeleted = await _basketService.RemoveBasketItemAsync(request.BasketItemId);
        if (!isDeleted)
        {
            throw new BaseException("Deleting failed");

        }

        return true;

    }
}