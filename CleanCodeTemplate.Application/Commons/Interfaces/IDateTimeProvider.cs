namespace CleanCodeTemplate.Application;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
