using ESIN.Clinic.CrossCutting.Categories;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using Microsoft.OpenApi.Models;

namespace ESIN.Clinic.Api.Categories;

public static class CategoryEndpoints
{
    public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/categories",
                         async (ICategoryService categoryService) =>
                         {
                             List<GetCategoriesQueryResponse> result = CategoryMapperService.ToResponse(await categoryService.GetCategories());
                             return TypedResults.Ok(result);
                         })
            .WithName("GetCategories")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Equipment category"} },
                Summary = "Retrieve all categories",
                Description = "Retrieve a list with information about each category."
            });
        
        endpoints.MapGet("/categories/{id:int}",
                         async (ICategoryService categoryService, int id) =>
                         {
                             GetCategoriesQueryResponse result = CategoryMapperService.ToResponse(await categoryService.GetCategoryById(id));

                             return Results.Ok(result);
                         })
            .WithName("GetCategoryById")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Tags = new List<OpenApiTag>{new(){Name = "Equipment category"} },
                Summary = "Retrieve one category",
                Description = "Retrieve information about required category, based on request id."
            });
        
    }
}