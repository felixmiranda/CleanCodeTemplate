using MediatR;

namespace CleanCodeTemplate.Application;

public class GetAllCustomerQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<CustomerResponseDto>>>
{

}
