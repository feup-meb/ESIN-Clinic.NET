using ESIN.Clinic.CrossCutting.Interventions;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Interventions;

public partial class InterventionDetails
{
    [Parameter] public int? Id { get; set; }
    private GetInterventionByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;

        var http = new HttpClient();

        item = await http.GetFromJsonAsync<GetInterventionByIdQueryResponse>($"http://localhost:5240/interventions/{Id}");
    }
}