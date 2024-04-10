using System.Text.Json;
using CleanCodeTemplate.Application;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CleanCodeTemplate.Api;

public class ValidationMiddleware
{
    public readonly RequestDelegate _next;
    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
            {
                Message = "Errores de validacion",
                Errors = ex.Errors,
            });

        }
    }
}
