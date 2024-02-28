using ESIN.Clinic.Application.HospitalUnits.Queries;
using ESIN.Clinic.CrossCutting.Features.HospitalUnits;
using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.HospitalUnits;

public partial class Index
{
    private IQueryable<GetHospitalUnitsQueryResponse>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private IQueryable<GetHospitalUnitsQueryResponse>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        var query = new GetHospitalUnitsQuery(HospitalUnitRepository);
        items = (await query.GetHospitalUnitsAsync()).AsQueryable();
    }
}