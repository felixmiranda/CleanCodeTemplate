using MediatR;

namespace CleanCodeTemplate.Application;

public class CreateUserCommand : IRequest<BaseResponse<bool>>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int State { get; set; }
}
