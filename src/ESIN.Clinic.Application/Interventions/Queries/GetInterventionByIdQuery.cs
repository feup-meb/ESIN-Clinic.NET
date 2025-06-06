using ESIN.Clinic.CrossCutting.Features.Interventions;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Interventions.Queries;

public class GetInterventionByIdQuery(IInterventionRepository interventionRepository)
{
    public async Task<GetInterventionByIdQueryResponse> GetInterventionByIdAsync(int id)
    {
        Intervention? equipment = await interventionRepository.GetInterventionById(id);

        if (equipment == default)
            throw new Exception("Intervention not found.");

        var interventionResult = equipment.MapToResponse();
        
        return interventionResult;
    }
}