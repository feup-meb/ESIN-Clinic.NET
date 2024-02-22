using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Equipments;

public partial class Index()
{
    private bool _clearItems = false;
    private IQueryable<Equipment>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private IQueryable<Equipment>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        items = (await getEquipmentsQuery.GetEquipmentsAsync()).AsQueryable();
    }
}