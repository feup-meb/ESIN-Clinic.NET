using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    public Task<IEnumerable<Equipment>> GetEquipments()
    {
        throw new NotImplementedException();
    }

    public Task<Equipment?> GetEquipmentById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Equipment> AddEquipment(Equipment equipment)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEquipment(Equipment equipment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEquipmentById(int id)
    {
        throw new NotImplementedException();
    }
}