using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Product;

public class DeleteProductCommand : IRequest<bool>
{
    public string Id { get; set; }
}