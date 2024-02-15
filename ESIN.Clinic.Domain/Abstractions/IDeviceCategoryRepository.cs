using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface IDeviceCategoryRepository
{
    Task<IEnumerable<DeviceCategory>> GetDeviceCategories();
    Task<DeviceCategory?> GetDeviceCategoryById(int id);
    Task<DeviceCategory> AddDeviceCategory(DeviceCategory deviceCategory);
    Task UpdateDeviceCategory(DeviceCategory deviceCategory);
    Task DeleteDeviceCategoryById(int id);
}