using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace CleanCodeTemplate.Application;

public class LoginHandler : IRequestHandler<LoginCommand, BaseResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<BaseResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<string>();
        try
        {
            var user = await _unitOfWork.User.UserByEmailAsync(request.Email);
            if (user is null)
            {
                response.IsSuccess = false;
                response.Message = "El Usuario y/o contraseña es incorreta";
                return response;
            }

            if (BC.Verify(request.Password, user.Password))
            {
                response.IsSuccess = true;
                response.Data = _jwtTokenGenerator.GenerateToken(user);
                response.Message = "Token Generado correctamente";
            }

        }
        catch (Exception ex)
        {

            response.Message = ex.Message;
        }
        return response;
    }
}
