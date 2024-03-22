﻿using MediatR;

namespace CleanCodeTemplate.Application;

public class UpdateCustomerCommand : IRequest<BaseResponse<bool>>
{

    public int CustomerId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? City { get; set; }
}
