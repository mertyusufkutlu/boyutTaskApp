namespace boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;

public class CreateBasketItemResponse
{
    public Guid BasketItemId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}