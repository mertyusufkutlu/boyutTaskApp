using boyutTaskAppAPI.Applicaton.Repositories;
using boyutTaskAppAPI.Applicaton.Repositories.Product;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Product;

public class CreateProductHandler : IRequestHandler<CreateProductRequest , CreateProductResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    public CreateProductHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }


    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var newProduct = new Domain.Entities.Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            ProductGroupId = request.ProductGroupId
        };

        var entityEntry = await _productWriteRepository.AddAsync(newProduct);
        await _productWriteRepository.SaveAsync();

        // Eklenen ürünün ID'sini almak için EntityEntry'den özelliklere erişin
        var addedProductId = newProduct.Id;

        return new CreateProductResponse()
        {
            Id = addedProductId
        };
    }
}