﻿using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ESIN.Clinic.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IHospitalUnitRepository, HospitalUnitRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        services.AddScoped<IInterventionRepository, InterventionRepository>();
        
        return services;
    }
}