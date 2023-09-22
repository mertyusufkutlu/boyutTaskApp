using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Queries.Product;

public class GetAllProductQueryRequest : IRequest<List<Domain.Entities.Product>>
{
    public Guid Id { get; set; }
}