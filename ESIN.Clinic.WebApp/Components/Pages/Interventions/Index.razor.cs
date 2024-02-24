using ESIN.Clinic.CrossCutting.Interventions;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Interventions;

public partial class Index
{
    private IQueryable<GetInterventionsQueryResponse>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private IQueryable<GetInterventionsQueryResponse>? FilteredItems 
        => items?.Where(x => x.EquipmentName.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        var http = new HttpClient();
        
        items = (await http.GetFromJsonAsync<List<GetInterventionsQueryResponse>>("http://localhost:5240/interventions"))!
            .AsQueryable();
    }
}