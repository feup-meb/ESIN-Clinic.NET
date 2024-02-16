using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetDeviceCategories();
    Task<Category?> GetDeviceCategoryById(int id);
    Task<Category> AddDeviceCategory(Category category);
    Task UpdateDeviceCategory(Category category);
    Task DeleteDeviceCategoryById(int id);
}