using boyutTaskAppAPI.Applicaton.Repositories.Product;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public DeleteProductHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var items = await _productWriteRepository.RemoveAsync(request.Id);
        await _productWriteRepository.SaveAsync();
        return true;
    }
}