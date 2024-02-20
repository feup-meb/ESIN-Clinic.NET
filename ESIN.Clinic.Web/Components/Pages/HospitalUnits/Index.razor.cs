using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace ESIN.Clinic.Web.Components.Pages.HospitalUnits;

public partial class Index
{
    private bool _clearItems = false;
    private IQueryable<HospitalUnit>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private GridSort<HospitalUnit> sort = GridSort<HospitalUnit>
        .ByDescending(x => x.Name)
        .ThenDescending(x => x.Room);

    private IQueryable<HospitalUnit>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        items = (await getHospitalUnitsQuery.GetHospitalUnitsAsync()).AsQueryable();
    }

    private void HandleCountryFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
            nameFilter = value;
    }

    private void HandleClear()
    {
        if (string.IsNullOrWhiteSpace(nameFilter))
            nameFilter = string.Empty;
    }
}