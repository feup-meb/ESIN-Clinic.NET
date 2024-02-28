using ESIN.Clinic.Application.Interventions.Queries;
using ESIN.Clinic.CrossCutting.Features.Interventions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace ESIN.Clinic.WebApp.Components.Pages.Interventions;

public partial class Index
{
    private IQueryable<GetInterventionsQueryResponse>? items;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    private string nameFilter = string.Empty;

    [Inject] public IConfiguration baseUrl { get; set; }
    private IQueryable<GetInterventionsQueryResponse>? FilteredItems 
        => items?.Where(x => x.EquipmentName.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

    protected override async Task OnInitializedAsync()
    {
        var query = new GetInterventionsQuery(InterventionRepository);
        items = (await query.GetInterventionsAsync()).AsQueryable();
    }
}