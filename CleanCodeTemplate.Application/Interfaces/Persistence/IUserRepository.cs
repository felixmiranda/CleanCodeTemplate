using CleanCodeTemplate.Domain;

namespace CleanCodeTemplate.Application;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> UserByEmailAsync(string email);
}
