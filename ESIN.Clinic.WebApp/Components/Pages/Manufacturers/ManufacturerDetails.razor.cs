using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Manufacturers;

public partial class ManufacturerDetails
{
    [Parameter] public int? Id { get; set; }
    private Manufacturer? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;

        item = await _manufacturerService.GetManufacturerById((int)Id);
    }
}