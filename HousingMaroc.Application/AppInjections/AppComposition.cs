using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HousingMaroc.Application.AppInjections;

public static class AppComposition
{
    public static IServiceCollection ConfigureApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddMediatR(c => { c.RegisterServicesFromAssembly(typeof(AppComposition).Assembly); });

        return services;
    }
}
