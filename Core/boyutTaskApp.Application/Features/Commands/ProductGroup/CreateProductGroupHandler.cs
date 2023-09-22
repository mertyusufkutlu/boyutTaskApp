using boyutTaskAppAPI.Applicaton.Features.Commands.Product;
using boyutTaskAppAPI.Applicaton.Repositories.ProductGroup;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.ProductGroup;

public class CreateProductGroupHandler : IRequestHandler<CreateProductGroupRequest, CreateProductGroupResponse>
{
    private readonly IProductGroupWriteRepository _productGroupWriteRepository;

    public CreateProductGroupHandler(IProductGroupWriteRepository productGroupWriteRepository)
    {
        _productGroupWriteRepository = productGroupWriteRepository;
    }

    public async Task<CreateProductGroupResponse> Handle(CreateProductGroupRequest request,
        CancellationToken cancellationToken)
    {
        var newProductGroup = new Domain.Entities.ProductGroup
        {
            Name = request.Name,
        };

        var entityEntry = await _productGroupWriteRepository.AddAsync(newProductGroup);
        await _productGroupWriteRepository.SaveAsync();

        // Eklenen ürünün ID'sini almak için EntityEntry'den özelliklere erişin
        var createdProductGroupId = newProductGroup.Id;
        return new CreateProductGroupResponse()
        {
            Id = createdProductGroupId,
            Name = request.Name
        };
    }
}