using ESIN.Clinic.Api.Categories;
using ESIN.Clinic.Api.HospitalUnits;
using ESIN.Clinic.Api.Manufacturers;
using ESIN.Clinic.Api.WeatherForecasts;

namespace ESIN.Clinic.Api;

public static class EndpointsMapper
{
    public static void MapRequests(this WebApplication app)
    {
        app.RegisterWeatherForecastEndpoints();
        
        app.RegisterCategoryEndpoints();
        // app.RegisterEmployeeEndpoints();
        // app.RegisterEquipmentEndpoints();
        app.RegisterHospitalUnitEndpoints();
        // app.RegisterInterventionEndpoints();
        app.RegisterManufacturerEndpoints();
        // app.RegisterUserRoleEndpoints();
    }
}