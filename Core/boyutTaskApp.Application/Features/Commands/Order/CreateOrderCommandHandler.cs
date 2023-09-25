using boyutTaskAppAPI.Applicaton.Services;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Order;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IOrderService _orderService;

    public CreateOrderCommandHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
      var savedOrder =  await _orderService.CreateOrderAsync(request);

      return savedOrder;
    }
}