using ESIN.Clinic.CrossCutting.Manufacturers;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using Microsoft.OpenApi.Models;

namespace ESIN.Clinic.Api.Manufacturers;

public static class ManufacturerEndpoints
{
    public static void RegisterManufacturerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/manufacturers",
                         async (IManufacturerService manufacturerService) =>
                         {
                             List<GetManufacturersQueryResponse> result = ManufacturerMapperService.ToResponse(await manufacturerService.GetManufacturers());
                             return TypedResults.Ok(result);
                         })
            .WithName("GetManufacturers")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Equipment manufacturer"} },
                Summary = "Retrieve all manufacturers",
                Description = "Retrieve a list with information about each manufacturer."
            });
        
        endpoints.MapGet("/manufacturers/{id:int}",
                         async (IManufacturerService manufacturerService, int id) =>
                         {
                             GetManufacturerByIdQueryResponse result = ManufacturerMapperService.ToResponse(await manufacturerService.GetManufacturerById(id));

                             return Results.Ok(result);
                         })
            .WithName("GetManufacturerById")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Equipment manufacturer"} },
                Summary = "Retrieve one manufacturer",
                Description = "Retrieve information about required manufacturer, based on request id."
            });
    }
}