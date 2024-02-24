using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Categories.Queries;

public class GetCategoryByIdQuery(ICategoryService categoryService)
{
    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await categoryService.GetCategoryById(id);

        if (category == default)
            throw new Exception("Category not found.");

        return category;
    }
}