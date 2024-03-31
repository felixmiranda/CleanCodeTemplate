namespace CleanCodeTemplate.Api;

public static class HealthCheckExtension
{
    public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("DockerConnection")!, tags: ["database"]);

        services.AddHealthChecksUI().AddInMemoryStorage();

        return services;
    }

}
