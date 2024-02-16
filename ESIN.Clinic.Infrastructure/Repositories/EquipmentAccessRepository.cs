using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class EquipmentAccessRepository : IEquipmentAccessRepository
{
    public Task<IEnumerable<EquipmentAccess>> GetEquipmentAccesses()
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentAccess?> GetEquipmentAccessById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<EquipmentAccess> AddEquipmentAccess(EquipmentAccess equipmentAccess)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEquipmentAccess(EquipmentAccess equipmentAccess)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEquipmentAccessById(int id)
    {
        throw new NotImplementedException();
    }
}