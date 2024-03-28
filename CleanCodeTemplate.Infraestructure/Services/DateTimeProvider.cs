using CleanCodeTemplate.Application;

namespace CleanCodeTemplate.Infraestructure;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
