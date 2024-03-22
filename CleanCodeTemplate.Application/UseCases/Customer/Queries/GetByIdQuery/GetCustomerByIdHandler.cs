using AutoMapper;
using MediatR;

namespace CleanCodeTemplate.Application;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, BaseResponse<CustomerByIdResponseDTO>>
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _UnitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<CustomerByIdResponseDTO>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<CustomerByIdResponseDTO>();

        try
        {
            var customer = await _UnitOfWork.Customer.GetByIdAsync(request.CustomerID);

            if (customer is null)
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros";
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<CustomerByIdResponseDTO>(customer);
            response.Message = "Consulta exitosa";

        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
