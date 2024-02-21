using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface IEquipmentAccessRepository
{
    Task<IEnumerable<EquipmentAccess>> GetEquipmentAccesses();
    Task<EquipmentAccess?> GetEquipmentAccessById(int id);
    Task<EquipmentAccess> AddEquipmentAccess(EquipmentAccess equipmentAccess);
    Task UpdateEquipmentAccess(EquipmentAccess equipmentAccess);
    Task DeleteEquipmentAccessById(int id);
}