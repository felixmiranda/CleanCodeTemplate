using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeTemplate.Application;

public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, BaseResponse<IEnumerable<CustomerResponseDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderingQuery _orderingQuery;

    public GetAllCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery orderingQuery)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _orderingQuery = orderingQuery;
    }

    public async Task<BaseResponse<IEnumerable<CustomerResponseDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<CustomerResponseDto>>();
        try
        {
            var customers = _unitOfWork.Customer.GetAllQueryable();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        customers = customers.Where(c => c.Name.Contains(request.TextFilter));
                        break;
                    case 2:
                        customers = customers.Where(c => c.LastName.Contains(request.TextFilter));
                        break;

                }
            }

            if (request.StateFilter is not null)
            {
                customers = customers.Where(c => c.State == request.StateFilter);
            }

            if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.StartDate))
            {
                customers = customers.Where(c => c.AuditCreateDate >= Convert.ToDateTime(request.StartDate)
                                                && c.AuditCreateDate <= Convert.ToDateTime(request.EndDate).AddDays(1));
            }

            request.Sort ??= "Id";

            var items = await _orderingQuery.Ordering(request, customers).ToListAsync(cancellationToken);

            // if (customers is null)
            // {
            //     response.IsSuccess = false;
            //     response.Message = "No se encontraron registros.";
            //     return response;
            // }

            response.IsSuccess = true;
            response.TotalRecords = await customers.CountAsync(cancellationToken);
            response.Data = _mapper.Map<IEnumerable<CustomerResponseDto>>(items);
            response.Message = "Consulta exitosa";

            return response;

        }
        catch (Exception ex)
        {

            response.Message = ex.Message;
        }

        return response;

    }
}
