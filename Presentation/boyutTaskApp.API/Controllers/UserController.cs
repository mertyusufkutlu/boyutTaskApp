using MediatR;
using Microsoft.AspNetCore.Mvc;
using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using boyutTaskAppAPI.Applicaton.Features.Commands.User;
using Microsoft.AspNetCore.Authorization;

namespace boyutTaskAppAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[GenericAuthorize("Login")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> UserCreate([FromBody] UserCreateRequest userCreateRequest)
    {
        var response = await _mediator.Send(userCreateRequest);
        return Ok(new BaseResponse<bool>(response));
    }
}