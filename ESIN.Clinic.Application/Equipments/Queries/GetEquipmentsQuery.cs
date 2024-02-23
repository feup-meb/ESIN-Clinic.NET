using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Equipments.Queries;

public class GetEquipmentsQuery(IEquipmentRepository equipmentRepository)
{
    public async Task<List<Equipment>> GetEquipmentsAsync()
    {
        var equipments = await equipmentRepository.GetEquipments();

        if (!equipments.Any())
            throw new Exception("No equipments found.");

        return equipments.ToList();
    }
}