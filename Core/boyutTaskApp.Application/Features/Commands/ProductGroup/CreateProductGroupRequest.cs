using boyutTaskAppAPI.Applicaton.Features.Commands.Product;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.ProductGroup;

public class CreateProductGroupRequest : IRequest<CreateProductGroupResponse>
{
    public string Name { get; set; }
}