using boyutTaskAppAPI.Applicaton.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace boyutTaskAppAPI.Applicaton.Features.Queries.Product;

public class GetAllProductHandler : IRequestHandler<GetAllProductQueryRequest , List<Domain.Entities.Product>>
{
    readonly IProductReadRepository _productReadRepository;
    public GetAllProductHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<List<Domain.Entities.Product>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var items = await _productReadRepository.GetAll().ToListAsync(cancellationToken);
        return items;
    }
}