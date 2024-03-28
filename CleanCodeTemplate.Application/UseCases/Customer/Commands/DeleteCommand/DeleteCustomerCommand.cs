using MediatR;

namespace CleanCodeTemplate.Application;

public class DeleteCustomerCommand : IRequest<BaseResponse<bool>>
{
    public int CustomerId { get; set; }
}
