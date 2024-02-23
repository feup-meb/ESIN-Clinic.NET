using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Interventions;

public partial class Index
{
    private IQueryable<Intervention>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private IQueryable<Intervention>? FilteredItems 
        => items?.Where(x => x.Equipment.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        items = (await getInterventionsQuery.GetInterventionsAsync()).AsQueryable();
    }
}