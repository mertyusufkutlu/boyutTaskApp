namespace boyutTaskAppAPI.Applicaton.Features.Commands.CustomerBasket;

public class CustomerBasketRequest
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
}