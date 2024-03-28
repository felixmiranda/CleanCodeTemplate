﻿using CleanCodeTemplate.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeTemplate.Api;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetCustomerList([FromQuery] GetAllCustomerQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
    [HttpGet("{customerId:int}")]
    public async Task<IActionResult> GetCustomerById([FromQuery] int customerId)
    {
        var response = await _mediator.Send(new GetCustomerByIdQuery()
        {
            CustomerID = customerId
        });
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CustomerRegister([FromBody] CreateCustomerCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> CustomerUpdate([FromBody] UpdateCustomerCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut("Delete/{customerId:int}")]
    public async Task<IActionResult> CustomerDelete(int customerId)
    {
        var response = await _mediator.Send(new DeleteCustomerCommand() { CustomerId = customerId });
        return Ok(response);
    }
}
