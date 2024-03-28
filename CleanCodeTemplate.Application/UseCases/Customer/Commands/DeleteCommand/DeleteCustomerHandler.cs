using MediatR;

namespace CleanCodeTemplate.Application;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseResponse<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var existsCustomer = await _unitOfWork.Customer.GetByIdAsync(request.CustomerId);

            if (existsCustomer is null)
            {
                response.IsSuccess = false;
                response.Message = "El cliente no existe en la base de datos.";
                return response;
            }

            await _unitOfWork.Customer.DeleteAsync(request.CustomerId);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "Eliminacion exitosa.";

        }
        catch (Exception ex)
        {

            response.Message = ex.Message;
        }

        return response;
    }
}
