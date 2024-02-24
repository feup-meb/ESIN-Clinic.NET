using ESIN.Clinic.CrossCutting.Equipments;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using Microsoft.OpenApi.Models;

namespace ESIN.Clinic.Api.Equipments;

public static class EquipmentEndpoints
{
    public static void RegisterEquipmentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/equipments",
                         async (IEquipmentService equipmentService) =>
                         {
                             List<GetEquipmentsQueryResponse> result = EquipmentMapperService.ToResponse(await equipmentService.GetEquipments());
                             return TypedResults.Ok(result);
                         })
            .WithName("GetEquipments")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Equipment equipment"} },
                Summary = "Retrieve all equipments",
                Description = "Retrieve a list with information about each equipment."
            });
        
        endpoints.MapGet("/equipments/{id:int}",
                         async (IEquipmentService equipmentService, int id) =>
                         {
                             GetEquipmentByIdQueryResponse result = EquipmentMapperService.ToResponse(await equipmentService.GetEquipmentById(id));

                             return Results.Ok(result);
                         })
            .WithName("GetEquipmentById")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Equipment equipment"} },
                Summary = "Retrieve one equipment",
                Description = "Retrieve information about required equipment, based on request id."
            });
        
    }
}