using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace ESIN.Clinic.Web.Components.Pages.Interventions;

public partial class Index
{
    private bool _clearItems = false;
    private IQueryable<Intervention>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private GridSort<Intervention> sort = GridSort<Intervention>
        .ByDescending(x => x.InterventionType)
        .ThenDescending(x => x.ReportDate)
        .ThenDescending(x => x.Equipment.Name);

    private IQueryable<Intervention>? FilteredItems 
        => items?.Where(x => x.Equipment.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        items = (await getInterventionsQuery.GetInterventionsAsync()).AsQueryable();
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