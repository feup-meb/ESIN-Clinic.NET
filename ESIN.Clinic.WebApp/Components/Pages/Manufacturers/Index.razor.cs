using ESIN.Clinic.Application.Manufacturers.Queries;
using ESIN.Clinic.CrossCutting.Features.Manufacturers;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Manufacturers;

public partial class Index
{
    private IQueryable<GetManufacturersQueryResponse>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;
    
    private IQueryable<GetManufacturersQueryResponse>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));
    
    protected override async Task OnInitializedAsync()
    {
        var query = new GetManufacturersQuery(ManufacturerRepository);
        items = (await query.GetManufacturersAsync()).AsQueryable();
    }
}