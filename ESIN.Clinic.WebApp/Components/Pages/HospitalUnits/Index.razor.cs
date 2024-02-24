using ESIN.Clinic.CrossCutting.HospitalUnits;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.HospitalUnits;

public partial class Index
{
    private IQueryable<GetHospitalUnitsQueryResponse>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    private IQueryable<GetHospitalUnitsQueryResponse>? FilteredItems =>
        items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        var http = new HttpClient();
        
        items = (await http.GetFromJsonAsync<List<GetHospitalUnitsQueryResponse>>("http://localhost:5240/units"))!
            .AsQueryable();
    }
}