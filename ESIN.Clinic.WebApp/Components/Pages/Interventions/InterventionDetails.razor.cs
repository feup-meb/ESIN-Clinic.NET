using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Interventions;

public partial class InterventionDetails
{
    [Parameter] public int? Id { get; set; }
    private Intervention? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;

        item = await _interventionService.GetInterventionById((int)Id);
    }
}