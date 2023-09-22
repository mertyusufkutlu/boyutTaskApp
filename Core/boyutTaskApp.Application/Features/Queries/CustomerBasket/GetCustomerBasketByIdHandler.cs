// using boyutTaskAppAPI.Applicaton.Repositories;
// using boyutTaskAppAPI.Domain.Entites;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace boyutTaskAppAPI.Applicaton.Features.Queries.CustomerBasket;
//
// public class GetCustomerBasketByIdHandler : IRequestHandler<GetCustomerBasketByIdQueryRequest, List<Domain.Entites.CustomerBasket>>
// {
//     readonly private ICustomerBasketReadRepository _customerBasketReadRepository;
//     
//     
//     public GetCustomerBasketByIdHandler(ICustomerBasketReadRepository customerBasketReadRepository)
//     {
//         _customerBasketReadRepository = customerBasketReadRepository;
//     }
//
//     public async Task<List<Domain.Entites.CustomerBasket>> Handle(GetCustomerBasketByIdQueryRequest request, CancellationToken cancellationToken)
//     {
//         var items = await _customerBasketReadRepository.GetAll().Where(x=>x.UserId == request.UserId).ToListAsync(cancellationToken);
//         return items;
//     }
// }