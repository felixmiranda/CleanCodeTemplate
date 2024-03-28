using CleanCodeTemplate.Application;
using CleanCodeTemplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeTemplate.Infraestructure;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> UserByEmailAsync(string email)
    {
        var user = await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.AuditDeleteUser == null && x.AuditDeleteDate == null);
        return user!;
    }
}
