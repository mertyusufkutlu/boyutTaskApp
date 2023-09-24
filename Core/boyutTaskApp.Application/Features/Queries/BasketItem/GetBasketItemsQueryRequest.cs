using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Queries.BasketItem;

public class GetBasketItemsQueryRequest : IRequest<List<GetBasketItemsQueryResponse>>

{
    public Guid UserId { get; set; }
}