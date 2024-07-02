using System.Text;
using FluentValidation;
using HousingMaroc.Application.Common.Auth;
using HousingMaroc.Application.Common.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HousingMaroc.Application;

public static class AppComposition
{
    public static IServiceCollection ConfigureApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddMediatR(c => { c.RegisterServicesFromAssembly(typeof(AppComposition).Assembly); });
        services.AddValidatorsFromAssembly(typeof(AppComposition).Assembly);
        services.AddScoped<IJWTHelper, JWTHelper>();
        services.AddScoped<IUserContext, UserContext>();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader() //  Allow all headers, including content-type
                        .AllowAnyMethod();
                });
        });
        
        RegisterAuthentication(services, configuration);

        return services;
    }


    private static void RegisterAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(AppPolicy.Authenticated, opt => { opt.RequireAuthenticatedUser(); });
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] ?? string.Empty))
                };
            });

        services.AddHttpContextAccessor();
    }
}
