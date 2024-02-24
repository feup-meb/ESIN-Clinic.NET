using ESIN.Clinic.CrossCutting.Equipments;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Equipments;

public partial class EquipmentDetails
{
    [Parameter] public int? Id { get; set; }
    private GetEquipmentByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;

        var http = new HttpClient();

        item = await http.GetFromJsonAsync<GetEquipmentByIdQueryResponse>($"http://localhost:5240/equipments/{Id}");
    }
}