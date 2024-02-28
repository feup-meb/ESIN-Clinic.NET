using ESIN.Clinic.CrossCutting.Features.Interventions;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;

namespace ESIN.Clinic.Application.Interventions.Queries;

public class GetInterventionsQuery(IInterventionRepository interventionRepository)
{
    public async Task<List<GetInterventionsQueryResponse>> GetInterventionsAsync()
    {
        var interventions = await interventionRepository.GetInterventions();

        if (!interventions.Any())
            throw new Exception("No interventions found.");

        List<GetInterventionsQueryResponse> interventionsResult = interventions.MapToResponse();

        return interventionsResult.ToList();
    }
}