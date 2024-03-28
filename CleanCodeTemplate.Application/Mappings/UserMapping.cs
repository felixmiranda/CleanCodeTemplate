using AutoMapper;
using CleanCodeTemplate.Domain;

namespace CleanCodeTemplate.Application;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<CreateUserCommand, User>();
    }
}
