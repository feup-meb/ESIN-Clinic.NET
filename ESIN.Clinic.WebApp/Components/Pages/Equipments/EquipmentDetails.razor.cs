using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Equipments;

public partial class EquipmentDetails
{
    [Parameter] public int? Id { get; set; }
    private Equipment? item;

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
            return;
        
        item = await _equipmentService.GetEquipmentById((int)Id);
    }
}