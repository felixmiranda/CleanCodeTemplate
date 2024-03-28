using CleanCodeTemplate.Domain;

namespace CleanCodeTemplate.Application;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
