using boyutTaskAppAPI.Applicaton.Features.Commands.Order;

namespace boyutTaskAppAPI.Applicaton.Services;

public interface IOrderService
{
    Task<CreateOrderCommandResponse> CreateOrderAsync(CreateOrderCommandRequest createOrderCommandRequest);
}