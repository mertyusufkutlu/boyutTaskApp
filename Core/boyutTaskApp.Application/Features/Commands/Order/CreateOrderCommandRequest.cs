using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Order;

public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
{
    public Guid BasketId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
}