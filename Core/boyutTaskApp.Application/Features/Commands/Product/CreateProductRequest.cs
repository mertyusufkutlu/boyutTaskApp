
using boyutTaskAppAPI.Domain.Entities;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Product;

public class CreateProductRequest : IRequest<CreateProductResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }

    public Guid? ProductGroupId { get; set; }
}