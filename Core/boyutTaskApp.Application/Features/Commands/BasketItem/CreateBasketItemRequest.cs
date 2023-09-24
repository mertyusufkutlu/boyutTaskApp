using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;

public class CreateBasketItemRequest : IRequest<CreateBasketItemResponse>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}