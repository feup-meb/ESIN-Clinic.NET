using ESIN.Clinic.CrossCutting.Features.Categories;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Categories.Queries;

public class GetCategoriesQuery(ICategoryRepository categoryRepository)
{
    public async Task<List<GetCategoriesQueryResponse>> GetCategoriesAsync()
    {
        List<Category> categories = await categoryRepository.GetCategories();
        
        if (categories.Count == 0)
            throw new Exception("No categories found.");

        List<GetCategoriesQueryResponse> categoriesResult = categories.MapToResponse();
        
        return categoriesResult.ToList();
    }
}