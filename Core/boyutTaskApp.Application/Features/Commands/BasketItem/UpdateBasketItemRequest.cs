using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;

public class UpdateBasketItemRequest : IRequest<bool>
{
    public Guid BasketItemId { get; set; }
    public int Quantity { get; set; }
}