using CleanCodeTemplate.Domain;

namespace CleanCodeTemplate.Application;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Customer> Customer { get; }
    Task SaveChangesAsync();
}
