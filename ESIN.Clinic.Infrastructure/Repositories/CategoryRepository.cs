using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class CategoryRepository(ClinicDbContext dbContext) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetCategories()
        => await dbContext.Categories.ToListAsync();
        

    public async Task<Category?> GetCategoryById(int id)
    {
        Category? category = await dbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (category == default)
            throw new InvalidOperationException("Invalid data...");
        
        return category;
    }

    public async Task<Category> AddCategory(Category category)
    {
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();
        return category;
    }

    public async Task UpdateCategory(Category category)
    {
        if (category == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.Entry(category).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategoryById(int id)
    {
        Category? category = await dbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (category == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
    }
}