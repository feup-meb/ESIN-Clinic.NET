using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class DeviceCategoryRepository(ClinicDbContext dbContext) : IDeviceCategoryRepository
{
    public async Task<IEnumerable<DeviceCategory>> GetDeviceCategories()
    {
        List<DeviceCategory> deviceCategories = await dbContext.DeviceCategories.ToListAsync();
        
        return deviceCategories;
    }

    public async Task<DeviceCategory?> GetDeviceCategoryById(int id)
    {
        DeviceCategory? deviceCategory = await dbContext.DeviceCategories
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (deviceCategory == default)
            throw new InvalidOperationException("Invalid data...");
        
        return deviceCategory;
    }

    public async Task<DeviceCategory> AddDeviceCategory(DeviceCategory deviceCategory)
    {
        dbContext.DeviceCategories.Add(deviceCategory);
        await dbContext.SaveChangesAsync();
        return deviceCategory;
    }

    public async Task UpdateDeviceCategory(DeviceCategory deviceCategory)
    {
        if (deviceCategory == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.Entry(deviceCategory).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteDeviceCategoryById(int id)
    {
        DeviceCategory? deviceCategory = await dbContext.DeviceCategories
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (deviceCategory == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.DeviceCategories.Remove(deviceCategory);
        await dbContext.SaveChangesAsync();
    }
}