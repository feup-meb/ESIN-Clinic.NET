using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.HospitalUnits;

public partial class HospitalUnitDetails
{
    [Parameter] public int? Id { get; set; }
    private HospitalUnit? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;

        item = await _hospitalUnitService.GetHospitalUnitById((int)Id);
    }
}