using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class CategoryRepository(ClinicDbContext dbContext) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetDeviceCategories()
    {
        List<Category> deviceCategories = await dbContext.Categories.ToListAsync();
        
        return deviceCategories;
    }

    public async Task<Category?> GetDeviceCategoryById(int id)
    {
        Category? deviceCategory = await dbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (deviceCategory == default)
            throw new InvalidOperationException("Invalid data...");
        
        return deviceCategory;
    }

    public async Task<Category> AddDeviceCategory(Category category)
    {
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();
        return category;
    }

    public async Task UpdateDeviceCategory(Category category)
    {
        if (category == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.Entry(category).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteDeviceCategoryById(int id)
    {
        Category? deviceCategory = await dbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (deviceCategory == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.Categories.Remove(deviceCategory);
        await dbContext.SaveChangesAsync();
    }
}