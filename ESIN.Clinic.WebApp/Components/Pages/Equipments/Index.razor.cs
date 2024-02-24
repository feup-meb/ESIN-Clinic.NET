using ESIN.Clinic.CrossCutting.Equipments;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Equipments;

public partial class Index()
{
    private IQueryable<GetEquipmentsQueryResponse>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private IQueryable<GetEquipmentsQueryResponse>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        var http = new HttpClient();
        
        items = (await http.GetFromJsonAsync<List<GetEquipmentsQueryResponse>>("http://localhost:5240/equipments"))!
            .AsQueryable();
    }
}