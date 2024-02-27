using ESIN.Clinic.Application.Categories.Queries;
using ESIN.Clinic.CrossCutting.Features.Categories;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Categories;

public partial class Index
{
    private IQueryable<GetCategoriesQueryResponse>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private IQueryable<GetCategoriesQueryResponse>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        var query = new GetCategoriesQuery(CategoryRepository);
        items = (await query.GetCategoriesAsync()).AsQueryable();
    }
}