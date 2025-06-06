using ESIN.Clinic.CrossCutting.Features.Equipments;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Equipments.Queries;

public class GetEquipmentByIdQuery(IEquipmentRepository equipmentRepository)
{
    public async Task<GetEquipmentByIdQueryResponse> GetEquipmentByIdAsync(int id)
    {
        Equipment? equipment = await equipmentRepository.GetEquipmentById(id);

        if (equipment == default)
            throw new Exception("Equipment not found.");

        var equipmentResult = equipment.MapToResponse();
        
        return equipmentResult;
    }
}