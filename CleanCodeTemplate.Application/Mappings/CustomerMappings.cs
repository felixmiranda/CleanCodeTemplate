using AutoMapper;
using CleanCodeTemplate.Domain;

namespace CleanCodeTemplate.Application;

public class CustomerMappings : Profile
{
    public CustomerMappings()
    {
        CreateMap<Customer, CustomerResponseDto>()
                    .ForMember(x => x.CustomerId, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.StateCustomer, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                    .ReverseMap();
    }
}
