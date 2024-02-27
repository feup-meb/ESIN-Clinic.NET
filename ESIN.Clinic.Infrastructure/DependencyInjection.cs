using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Infrastructure.Context;
using ESIN.Clinic.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESIN.Clinic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<ClinicDbContext>(opt => opt.UseSqlServer(connectionString));
        
        services.AddHostedService<MigratorHostedService>();
        
        return services;
    }
    
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddTransient<IHospitalUnitService, HospitalUnitService>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IManufacturerService, ManufacturerService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        services.AddTransient<IEquipmentService, EquipmentService>();
        services.AddTransient<IInterventionService, InterventionService>();
        
        return services;
    }
}