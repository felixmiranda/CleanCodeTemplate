using CleanCodeTemplate.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeTemplate.Api;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerList([FromQuery] GetAllCustomerQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}
