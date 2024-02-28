using ESIN.Clinic.Application.Equipments.Queries;
using ESIN.Clinic.CrossCutting.Features.Equipments;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Equipments;

public partial class EquipmentDetails
{
    [Parameter] public int Id { get; set; }
    private GetEquipmentByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        var query = new GetEquipmentByIdQuery(EquipmentRepository);
        item = await query.GetEquipmentByIdAsync(Id);
        
    }
}