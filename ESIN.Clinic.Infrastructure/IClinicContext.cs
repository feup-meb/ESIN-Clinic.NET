using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure;

public interface IClinicContext
{
    public List<HospitalUnit> HospitalUnits();
    public List<UserRole> UserRoles();
    public List<Employee> Employees();
    public List<Manufacturer> Manufacturers();
    public List<Category> DeviceCategories();
    public List<Equipment> Devices();
    public List<Intervention> Interventions();
    public List<EquipmentAccess> DevicesAccesses();
}