namespace boyutTaskAppAPI.Applicaton.Features.Queries.Product;

public class GetAllProductResponse
{
    public int TotalCount { get; set; }
    public Domain.Entities.Product Products { get; set; }
}