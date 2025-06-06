using ESIN.Clinic.CrossCutting.Features.Categories;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Categories.Queries;

public class GetCategoryByIdQuery(ICategoryRepository categoryRepository)
{
    public async Task<GetCategoryByIdQueryResponse> GetCategoryByIdAsync(int id)
    {
        Category? category = await categoryRepository.GetCategoryById(id);

        if (category == default)
            throw new Exception("Category not found.");

        var categoryResult = category.MapToResponse();
        
        return categoryResult;
    }
}