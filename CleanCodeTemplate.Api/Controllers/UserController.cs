using CleanCodeTemplate.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeTemplate.Api;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> UserCreate([FromBody] CreateUserCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
