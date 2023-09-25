namespace boyutTaskAppAPI.Applicaton.Features.Commands.Order;

public class CreateOrderCommandResponse
{
    public Guid OrderId { get; set; }
    // public Guid BasketId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
}