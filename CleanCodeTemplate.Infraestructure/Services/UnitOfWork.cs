using CleanCodeTemplate.Application;
using CleanCodeTemplate.Domain;

namespace CleanCodeTemplate.Infraestructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IGenericRepository<Customer> _customer = null!;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Customer> Customer => _customer ?? new GenericRepository<Customer>(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
