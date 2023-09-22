// using boyutTaskAppAPI.Applicaton.Repositories;
// using MediatR;
//
// namespace boyutTaskAppAPI.Applicaton.Features.Commands.Product;
//
// public class CreateProductHandler : IRequestHandler<CreateProductCommand , List<Domain.Entites.Product>>
// {
//     
//     readonly IProductWriteRepository _productWriteRepository;
//     public CreateProductHandler(IProductWriteRepository productWriteRepository)
//     {
//         _productWriteRepository = productWriteRepository;
//     }
//
//
//     public async Task<List<Domain.Entites.Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
//     {
//         
//         var items = await _productWriteRepository.AddAsync(new()
//         {
//             Name = request.Name,
//             Price = request.Price,
//             Stock = request.Stock,
//             ProductGroupId = request.ProductGroupId,
//         });
//         await _productWriteRepository.SaveAsync();
//         return new();
//     }
// }