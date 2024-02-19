using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Categories;

public class CategoryQueries(ICategoryRepository categoryRepository)
{
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var categories = await categoryRepository.GetCategories();

        if (!categories.Any())
            throw new Exception("No categories found.");

        return categories;
    }
    
    public async Task<Category> GetCategoryById(int id)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(id);

        if (category == default)
            throw new Exception("Category not found.");

        return category;
    }
}