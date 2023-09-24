using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using boyutTaskAppAPI.Applicaton.Features.Commands.Product;
using boyutTaskAppAPI.Applicaton.Features.Commands.ProductGroup;
using boyutTaskAppAPI.Applicaton.Features.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace boyutTaskAppAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[GenericAuthorize("Login")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var response =  await _mediator.Send(new GetAllProductQueryRequest());
        return Ok(response);
         
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Post(CreateProductRequest createProductRequest)
    {
        var response =  await _mediator.Send(createProductRequest);
        return Ok(new BaseResponse<CreateProductResponse>(response));
    }
    
    [HttpPost("create-group")]
    public async Task<IActionResult> Post(CreateProductGroupRequest createProductGroupRequest)
    {
        var response =  await _mediator.Send(createProductGroupRequest);
        return Ok(new BaseResponse<CreateProductGroupResponse>(response));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response =  await _mediator.Send(new DeleteProductCommand{ Id = id});
        return Ok(response);
    }
}