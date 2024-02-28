using ESIN.Clinic.Application.HospitalUnits.Queries;
using ESIN.Clinic.CrossCutting.Features.HospitalUnits;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.HospitalUnits;

public partial class HospitalUnitDetails
{
    [Parameter] public int Id { get; set; }
    private GetHospitalUnitByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        var query = new GetHospitalUnitByIdQuery(HospitalUnitRepository);
        item = await query.GetHospitalUnitByIdAsync(Id);
    }
}