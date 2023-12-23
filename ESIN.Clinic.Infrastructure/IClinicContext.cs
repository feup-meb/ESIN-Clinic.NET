using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure;

public interface IClinicContext
{
    public List<HospitalUnit> HospitalUnits();
    public List<UserType> UserTypes();
    public List<Employee> Employees();
    public List<Manufacturer> Manufacturers();
    public List<DeviceCategory> DeviceCategories();
    public List<Device> Devices();
    public List<Intervention> Interventions();
    public List<DeviceAccess> DevicesAccesses();
}