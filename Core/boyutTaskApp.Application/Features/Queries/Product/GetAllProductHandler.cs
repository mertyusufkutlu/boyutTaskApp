// using boyutTaskAppAPI.Applicaton.Repositories;
// using boyutTaskAppAPI.Domain.Entites;
// using MediatR;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
//
// namespace boyutTaskAppAPI.Applicaton.Features.Queries.GetAllProduct;
//
// public class GetAllProductHandler : IRequestHandler<GetAllProductQueryRequest , List<Product>>
// {
//     readonly IProductReadRepository _productReadRepository;
//     public GetAllProductHandler(IProductReadRepository productReadRepository)
//     {
//         _productReadRepository = productReadRepository;
//     }
//
//     public async Task<List<Product>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
//     {
//         var items = await _productReadRepository.GetAll().ToListAsync();
//         return items;
//     }
// }