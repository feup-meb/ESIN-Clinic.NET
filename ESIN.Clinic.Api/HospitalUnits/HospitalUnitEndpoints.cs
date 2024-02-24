using ESIN.Clinic.CrossCutting.Categories;
using ESIN.Clinic.CrossCutting.HospitalUnits;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using Microsoft.OpenApi.Models;

namespace ESIN.Clinic.Api.HospitalUnits;

public static class HospitalUnitEndpoints
{
    public static void RegisterHospitalUnitEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/units",
                         async (IHospitalUnitService hospitalUnitService) =>
                         {
                             List<GetHospitalUnitsQueryResponse> result = HospitalUnitMapperService.ToResponse(await hospitalUnitService.GetHospitalUnits());
                             return TypedResults.Ok(result);
                         })
            .WithName("GetHospitalUnits")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Hospital Unit"} },
                Summary = "Retrieve all hospital units",
                Description = "Retrieve a list with information about each hospital unit."
            });
        
        endpoints.MapGet("/units/{id:int}",
                         async (IHospitalUnitService hospitalUnitService, int id) =>
                         {
                             GetHospitalUnitByIdQueryResponse result = HospitalUnitMapperService.ToResponse(await hospitalUnitService.GetHospitalUnitById(id));

                             return Results.Ok(result);
                         })
            .WithName("GetHospitalUnitById")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Hospital Unit"} },
                Summary = "Retrieve one hospital unit",
                Description = "Retrieve information about required hospital unit, based on request id."
            });
        
    }
}