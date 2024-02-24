using ESIN.Clinic.CrossCutting.HospitalUnits;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.HospitalUnits;

public partial class HospitalUnitDetails
{
    [Parameter] public int? Id { get; set; }
    private GetHospitalUnitByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;

        var http = new HttpClient();

        item = await http.GetFromJsonAsync<GetHospitalUnitByIdQueryResponse>($"http://localhost:5240/units/{Id}");
    }
}