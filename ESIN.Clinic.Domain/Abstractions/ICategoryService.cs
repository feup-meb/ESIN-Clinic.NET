using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface ICategoryService
{
    Task<List<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task<Category> AddCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategoryById(int id);
}