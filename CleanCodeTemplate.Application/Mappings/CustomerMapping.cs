using AutoMapper;
using CleanCodeTemplate.Domain;

namespace CleanCodeTemplate.Application;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomerResponseDto>()
                    .ForMember(x => x.CustomerId, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.StateCustomer, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                    .ReverseMap();

        CreateMap<Customer, CustomerByIdResponseDTO>()
                    .ForMember(x => x.CustomerId, x => x.MapFrom(y => y.Id))
                    .ReverseMap();

        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();

    }
}
