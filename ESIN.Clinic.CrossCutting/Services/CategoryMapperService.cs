using ESIN.Clinic.CrossCutting.Categories;
using ESIN.Clinic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ESIN.Clinic.CrossCutting.Services;

public static class CategoryMapperService
{
    public static List<GetCategoriesQueryResponse> ToResponse(List<Category> categories)
    {
        if(categories.IsNullOrEmpty())
            return [];

        List<GetCategoriesQueryResponse> response = [];
        categories.ToList().ForEach(x => response.Add(new GetCategoriesQueryResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description ?? string.Empty
        }));

        return response;
    }
    
    public static GetCategoryByIdQueryResponse ToResponse(Category category)
    {
        var response = new GetCategoryByIdQueryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description ?? string.Empty
        };

        return response;
    }
}