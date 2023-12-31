﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using boyutTaskAppAPI.Applicaton.Features.Commands.Auth;
using boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;
using Microsoft.AspNetCore.Authorization;

namespace boyutTaskAppAPI.API.Controllers;

[ApiController]
[GenericAuthorize("Login")]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [Route("send-sms")]
    [HttpPost]
    public async Task<IActionResult> SendSms(RegisterCommandRequest registerCommandRequest)
    {
        var response = await _mediator.Send(registerCommandRequest);
        return Ok(new BaseResponse<bool>(response));
    }

    [AllowAnonymous]
    [Route("verify-sms-code")]
    [HttpPost]
    public async Task<IActionResult> VerifySms([FromBody] VerifyCodeCommandRequest verifyCodeRequest)
    {
        var response = await _mediator.Send(verifyCodeRequest);
        return Ok(new BaseResponse<bool>(response));
    }

    [Route("create-token")]
    [HttpPost]
    public async Task<IActionResult> CreateToken([FromBody] KeyCloakUserRequest keyCloakUserRequest)
    {
        var response = await _mediator.Send(keyCloakUserRequest);
        return Ok(new BaseResponse<KeyCloakResponse>(response));
    }

    [Route("keycloak-access-token")]
    [HttpPost]
    public async Task<IActionResult> GetKeyCloakTokenAsync(
        [FromBody] GetKeyCloakTokenRequest getKeyCloakTokenRequest)
    {
        var response = await _mediator.Send(getKeyCloakTokenRequest);
        return Ok(new BaseResponse<KeyCloakResponse>(response));
    }

    [AllowAnonymous]
    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        var response = await _mediator.Send(loginRequest);
        return Ok(response);
    }
}