using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using boyutTaskAppAPI.Applicaton.Features.Commands.Order;
using boyutTaskAppAPI.Applicaton.Features.Commands.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace boyutTaskAppAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[GenericAuthorize("Login")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [GenericAuthorize("Admin")]
    [HttpPost("create")]
    public async Task<IActionResult> Post(CreateOrderCommandRequest createProductRequest)
    {
        var response =  await _mediator.Send(createProductRequest);
        return Ok(new BaseResponse<CreateOrderCommandResponse>(response));
    }
}