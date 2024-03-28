using MediatR;

namespace CleanCodeTemplate.Application;

public class LoginCommand : IRequest<BaseResponse<string>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
