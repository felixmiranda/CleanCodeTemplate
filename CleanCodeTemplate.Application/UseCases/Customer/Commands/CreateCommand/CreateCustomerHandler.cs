using AutoMapper;
using CleanCodeTemplate.Domain;
using MediatR;

namespace CleanCodeTemplate.Application;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<BaseResponse<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
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
