using boyutTaskAppAPI.Applicaton.Repositories.Product;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, List<Domain.Entities.Product>>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public DeleteProductHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<List<Domain.Entities.Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var items = await _productWriteRepository.RemoveAsync(request.Id);
        await _productWriteRepository.SaveAsync();
        return new();
    }
}