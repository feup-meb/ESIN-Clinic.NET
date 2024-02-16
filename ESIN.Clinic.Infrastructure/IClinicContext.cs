using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure;

public interface IClinicContext
{
    public List<HospitalUnit> HospitalUnits();
    public List<UserRole> UserRoles();
    public List<Employee> Employees();
    public List<Manufacturer> Manufacturers();
    public List<Category> Categories();
    public List<Equipment> Equipments();
    public List<Intervention> Interventions();
    public List<EquipmentAccess> DevicesAccesses();
}