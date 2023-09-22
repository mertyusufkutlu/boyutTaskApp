using MediatR;
using Microsoft.AspNetCore.Mvc;
using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Features.Commands.User;

namespace boyutTaskAppAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> UserCreate([FromBody] UserCreateRequest userCreateRequest)
    {
        var response = await _mediator.Send(userCreateRequest);
        return Ok(new BaseResponse<bool>(response));
    }
}