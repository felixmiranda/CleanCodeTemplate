using AutoMapper;
using CleanCodeTemplate.Domain;
using FluentValidation;
using MediatR;

namespace CleanCodeTemplate.Application;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCustomerCommand> _validator;

    public CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCustomerCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }


    public async Task<BaseResponse<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var results = await _validator.ValidateAsync(request, cancellationToken);

            if (!results.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Errores de validacion";
                return response;
            }

            var customer = _mapper.Map<Customer>(request);
            await _unitOfWork.Customer.CreateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "Registro exitoso";

        }
        catch (Exception ex)
        {

            response.Message = ex.Message;

        }

        return response;
    }
}
