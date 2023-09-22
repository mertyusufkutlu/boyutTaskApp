using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Product;

public class DeleteProductCommand : IRequest<List<Domain.Entities.Product>>
{
    public string Id { get; set; }
}