using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Interventions.Queries;

public class GetInterventionsQuery(IInterventionService interventionService)
{
    public async Task<List<Intervention>> GetInterventionsAsync()
    {
        var interventions = await interventionService.GetInterventions();

        if (!interventions.Any())
            throw new Exception("No interventions found.");

        return interventions.ToList();
    }
}