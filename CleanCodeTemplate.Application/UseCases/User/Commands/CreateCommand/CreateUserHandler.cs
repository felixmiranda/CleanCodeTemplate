using AutoMapper;
using CleanCodeTemplate.Domain;
using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace CleanCodeTemplate.Application;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var user = _mapper.Map<User>(request);
            user.Password = BC.HashPassword(user.Password);
            await _unitOfWork.User.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "Registro exitoso.";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;

        }

        return response;
    }
}
