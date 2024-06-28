using HousingMaroc.Application.AppInjections;
using HousingMaroc.Infrastructure;

namespace HousingMaroc.AppInjections;

public static class CompositionRoot
{
    public static void RegisterAppDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.ConfigureInfrastructureServices(configuration);
        serviceCollection.ConfigureApplicationServices(configuration);
    }
}
