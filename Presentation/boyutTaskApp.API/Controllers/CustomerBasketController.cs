using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using boyutTaskAppAPI.Applicaton.Repositories.CustomerBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace boyutTaskAppAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[GenericAuthorize("Login")]

public class CustomerBasketController : ControllerBase
{
    private readonly ICustomerBasketReadRepository _customerBasketReadRepository;
    private readonly ICustomerBasketWriteRepository _customerBasketWriteRepository;
    readonly private IMediator _mediator;

    public CustomerBasketController(ICustomerBasketReadRepository customerBasketReadRepository,
        ICustomerBasketWriteRepository customerBasketWriteRepository, IMediator mediator)
    {
        _customerBasketReadRepository = customerBasketReadRepository;
        _customerBasketWriteRepository = customerBasketWriteRepository;
        _mediator = mediator;
    }
    // [HttpGet("{userId}")]
    // public async Task<IActionResult> GetById(Guid userId)
    // {
    //     var response = await _mediator.Send(new GetCustomerBasketByIdQueryRequest { UserId = userId });
    //     return Ok(response);
    // }
    
    // [HttpPost]
    // public async Task<IActionResult> Post(VM_CustomerBasket model)
    // {
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