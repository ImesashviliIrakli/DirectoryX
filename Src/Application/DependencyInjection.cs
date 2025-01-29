using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            //configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        return services;
    }
}
