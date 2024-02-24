using ESIN.Clinic.CrossCutting.Categories;
using ESIN.Clinic.Domain.Entities;
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
        var http = new HttpClient();
        
        items = (await http.GetFromJsonAsync<List<GetCategoriesQueryResponse>>("http://localhost:5240/categories"))!
            .AsQueryable();
    }
}