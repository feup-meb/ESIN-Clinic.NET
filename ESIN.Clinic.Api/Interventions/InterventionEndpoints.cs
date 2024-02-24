using ESIN.Clinic.CrossCutting.Interventions;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using Microsoft.OpenApi.Models;

namespace ESIN.Clinic.Api.Interventions;

public static class InterventionEndpoints
{
    public static void RegisterInterventionEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/interventions",
                         async (IInterventionService interventionService) =>
                         {
                             List<GetInterventionsQueryResponse> result = InterventionMapperService.ToResponse(await interventionService.GetInterventions());
                             return TypedResults.Ok(result);
                         })
            .WithName("GetInterventions")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Intervention intervention"} },
                Summary = "Retrieve all interventions",
                Description = "Retrieve a list with information about each intervention."
            });
        
        endpoints.MapGet("/interventions/{id:int}",
                         async (IInterventionService interventionService, int id) =>
                         {
                             GetInterventionByIdQueryResponse result = InterventionMapperService.ToResponse(await interventionService.GetInterventionById(id));

                             return Results.Ok(result);
                         })
            .WithName("GetInterventionById")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Intervention intervention"} },
                Summary = "Retrieve one intervention",
                Description = "Retrieve information about required intervention, based on request id."
            });
        
    }
}