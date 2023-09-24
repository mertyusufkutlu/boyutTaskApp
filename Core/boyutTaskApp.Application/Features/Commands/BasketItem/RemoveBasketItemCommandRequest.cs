using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;

public class RemoveBasketItemCommandRequest : IRequest<bool>
{
    public Guid BasketItemId { get; set; }
}