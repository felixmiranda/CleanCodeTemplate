using AutoMapper;
using CleanCodeTemplate.Domain;
using MediatR;

namespace CleanCodeTemplate.Application;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(request);
            customer.Id = request.CustomerId;
            _unitOfWork.Customer.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "Actualizacion exitosa";

        }
        catch (Exception ex)
        {

            response.Message = ex.Message;
        }

        return response;

    }
}
