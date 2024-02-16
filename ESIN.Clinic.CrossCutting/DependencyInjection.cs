using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Infrastructure.Context;
using ESIN.Clinic.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESIN.Clinic.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ClinicDbContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        return services;
    }
}