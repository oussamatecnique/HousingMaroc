using HousingMaroc.Application.Common;
using HousingMaroc.Application.Users.Repositories;
using HousingMaroc.Infrastructure.Common;
using HousingMaroc.Infrastructure.Housing.Repositories;
using HousingMaroc.Infrastructure.Users.Repositories;

namespace HousingMaroc.Infrastructure;

public static class InfrastructureComposition
{
    public static IServiceCollection ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ApplicationDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IHousingRepository, HousingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
