using Api.Middleware;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class AppBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

    public static void UseCustomLanguageHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<LanguageMiddleware>();
    }
}