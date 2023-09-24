using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Services;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;

public class UpdateItemBasketCommandHandler : IRequestHandler<UpdateBasketItemRequest, bool>
{
    private readonly IBasketService _basketService;

    public UpdateItemBasketCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<bool> Handle(UpdateBasketItemRequest request, CancellationToken cancellationToken)
    {
       var updatedItem = await _basketService.UpdateQuantityAsync(request);
       if (!updatedItem)
       {
           throw new BaseException("Error while updating item quantity");
       }

       return true;
    }
}