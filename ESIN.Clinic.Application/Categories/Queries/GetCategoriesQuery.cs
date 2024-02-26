using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Categories.Queries;

public class GetCategoriesQuery(ICategoryService categoryService)
{
    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = await categoryService.GetCategories();

        if (!categories.Any())
            throw new Exception("No categories found.");

        return categories.ToList();
    }
}