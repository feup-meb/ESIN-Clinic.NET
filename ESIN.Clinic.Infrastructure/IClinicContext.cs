using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure;

public interface IClinicContext
{
    public List<HospitalUnit> GetHospitalUnits();
    public List<UserType> GetUserTypes();
    public List<Employee> GetEmployees();
    public List<Manufacturer> GetManufacturers();
    public List<DeviceCategory> GetDeviceCategories();
    public List<Device> GetDevices();
    public List<Intervention> GetInterventions();
    public List<DeviceAccess> GetDevicesAccesses();
}