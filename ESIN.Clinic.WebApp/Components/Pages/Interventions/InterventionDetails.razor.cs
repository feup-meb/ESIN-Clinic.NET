using ESIN.Clinic.Application.Interventions.Queries;
using ESIN.Clinic.CrossCutting.Features.Interventions;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Interventions;

public partial class InterventionDetails
{
    [Parameter] public int Id { get; set; }
    private GetInterventionByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        var query = new GetInterventionByIdQuery(InterventionRepository);
        item = await query.GetInterventionByIdAsync(Id);
    }
}