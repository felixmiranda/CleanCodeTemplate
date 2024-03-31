namespace CleanCodeTemplate.Api;

public static class MiddlewareExtension
{
    public static IApplicationBuilder AddMiddlewareValitation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidationMiddleware>();
    }
}
