using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Interventions;

public class GetInterventionsQuery(IInterventionRepository interventionRepository)
{
    public async Task<List<Intervention>> GetInterventionsAsync()
    {
        var interventions = await interventionRepository.GetInterventions();

        if (!interventions.Any())
            throw new Exception("No interventions found.");

        return interventions.ToList();
    }
}