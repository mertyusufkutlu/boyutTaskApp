namespace boyutTaskAppAPI.Applicaton.Features.Queries.BasketItem;

public class GetBasketItemsQueryResponse
{
    public Guid BasketItemId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
}