using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Manufacturers;

public partial class Index
{
    private IQueryable<Manufacturer>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;
    
    private IQueryable<Manufacturer>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));
    
    protected override async Task OnInitializedAsync()
    {
        items = (await getManufacturersQuery.GetManufacturersAsync()).AsQueryable();
    }
}