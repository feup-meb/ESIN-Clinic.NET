using ESIN.Clinic.CrossCutting.Features.Equipments;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;

namespace ESIN.Clinic.Application.Equipments.Queries;

public class GetEquipmentsQuery(IEquipmentRepository equipmentRepository)
{
    public async Task<List<GetEquipmentsQueryResponse>> GetEquipmentsAsync()
    {
        var equipments = await equipmentRepository.GetEquipments();

        if (!equipments.Any())
            throw new Exception("No equipments found.");

        List<GetEquipmentsQueryResponse> equipmentsResult = equipments.MapToResponse();

        return equipmentsResult.ToList();
    }
}