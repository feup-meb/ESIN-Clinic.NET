using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Equipments;

public partial class Index()
{
    private bool _clearItems = false;
    private IQueryable<Equipment>? items;
    // private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    // private GridSort<Equipment> sort = GridSort<Equipment>
    //     .ByDescending(x => x.Name)
    //     .ThenDescending(x => x.Description);

    private IQueryable<Equipment>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        items = (await getEquipmentsQuery.GetEquipmentsAsync()).AsQueryable();
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