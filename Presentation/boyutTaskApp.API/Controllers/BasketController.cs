using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace boyutTaskAppAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[GenericAuthorize("Login")]

public class BasketController : ControllerBase
{
    
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // [HttpGet("{userId}")]
    // public async Task<IActionResult> GetById(Guid userId)
    // {
    //     var response = await _mediator.Send(new GetCustomerBasketByIdQueryRequest { UserId = userId });
    //     return Ok(response);
    // }
    
    // [HttpPost]
    // public async Task<IActionResult> Post(CustomerBasketRequest customerBasketRequest)
    // {
    //     
    //     var response =  await _mediator.Send(customerBasketRequest);
    //     return Ok(new BaseResponse<CreateBasketResponse>(response));
    //     
    //     await _customerBasketWriteRepository.AddAsync(new()
    //     {
    //         ProductId = model.ProductId,
    //         UserId = model.UserId
    //     });
    //     await _customerBasketWriteRepository.SaveAsync();
    //     return StatusCode((int)HttpStatusCode.Created);
    // }
    
    // [HttpPut]
    // public async Task<IActionResult> Put()
    // {
    //     return Ok();
    // }

    
}