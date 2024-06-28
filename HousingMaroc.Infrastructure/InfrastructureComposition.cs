namespace HousingMaroc.Infrastructure;

public static class InfrastructureComposition
{
    public static IServiceCollection ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ApplicationDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IHouseRepository, HouseRepository>();

        return services;
    }
}
