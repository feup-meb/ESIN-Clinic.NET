using ESIN.Clinic.CrossCutting.Manufacturers;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Manufacturers;

public partial class ManufacturerDetails
{
    [Parameter] public int? Id { get; set; }
    private GetManufacturerByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;

        var http = new HttpClient();

        item = await http.GetFromJsonAsync<GetManufacturerByIdQueryResponse>($"http://localhost:5240/manufacturers/{Id}");
    }
}