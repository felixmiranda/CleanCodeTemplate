using MediatR;

namespace CleanCodeTemplate.Application;

public class CreateCustomerCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? City { get; set; }
}
