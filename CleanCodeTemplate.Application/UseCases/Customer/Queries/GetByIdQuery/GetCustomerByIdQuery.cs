using MediatR;

namespace CleanCodeTemplate.Application;

public class GetCustomerByIdQuery : IRequest<BaseResponse<CustomerByIdResponseDTO>>
{
    public int CustomerID { get; set; }
}
