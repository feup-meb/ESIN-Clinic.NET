using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Manufacturers;

public partial class Index
{
    private bool _clearItems = false;
    private IQueryable<Manufacturer>? items;
    // private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    // private GridSort<Manufacturer> sort = GridSort<Manufacturer>
    //     .ByDescending(x => x.Name);

    private IQueryable<Manufacturer>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        items = (await getManufacturersQuery.GetManufacturersAsync()).AsQueryable();
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