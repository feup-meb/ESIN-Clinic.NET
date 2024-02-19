using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Categories;

public class GetCategoriesQuery(ICategoryRepository categoryRepository)
{
    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = await categoryRepository.GetCategories();

        if (!categories.Any())
            throw new Exception("No categories found.");

        return categories.ToList();
    }
}