using ESIN.Clinic.Application.Categories.Queries;
using ESIN.Clinic.Application.Equipments.Queries;
using ESIN.Clinic.Application.HospitalUnits.Queries;
using ESIN.Clinic.Application.Interventions.Queries;
using ESIN.Clinic.Application.Manufacturers.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ESIN.Clinic.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetCategoriesQuery>();
        services.AddScoped<GetCategoryByIdQuery>();
        services.AddScoped<GetEquipmentsQuery>();
        services.AddScoped<GetHospitalUnitsQuery>();
        services.AddScoped<GetManufacturersQuery>();
        services.AddScoped<GetInterventionsQuery>();
        
        return services;
    }
}