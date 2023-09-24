using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;
using boyutTaskAppAPI.Applicaton.Features.Queries.BasketItem;
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

    [HttpGet]
    public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest getBasketItemsQuery)
    {
        var response = await _mediator.Send(getBasketItemsQuery);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddBasketItems(CreateBasketItemRequest createBasketItemRequest)
    {
        var response = await _mediator.Send(createBasketItemRequest);
        return Ok(new BaseResponse<CreateBasketItemResponse>(response));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBasketItemQuantity(UpdateBasketItemRequest updateBasketItemRequest)
    {
        var response = await _mediator.Send(updateBasketItemRequest);
        return Ok(new BaseResponse<bool>(response));
    }

    //TODO: FromQuery for just backend need to be FromRoute
    [HttpDelete]
    public async Task<IActionResult> DeleteBasketItems(
        [FromQuery] RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
    {
        var response = await _mediator.Send(removeBasketItemCommandRequest);
        return Ok(new BaseResponse<bool>(response));
    }
}