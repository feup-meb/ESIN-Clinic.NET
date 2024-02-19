using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace ESIN.Clinic.Web.Components.Pages.Categories;

public partial class Index
{
    private bool _clearItems = false;
    private IQueryable<Category>? items;
    private PaginationState pagination = new() { ItemsPerPage = 2 };
    private string nameFilter = string.Empty;

    private GridSort<Category> rankSort = GridSort<Category>
        .ByDescending(x => x.Name)
        .ThenDescending(x => x.Description);

    private IQueryable<Category>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        items = (await GetCategoriesQuery.GetCategoriesAsync()).AsQueryable();
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