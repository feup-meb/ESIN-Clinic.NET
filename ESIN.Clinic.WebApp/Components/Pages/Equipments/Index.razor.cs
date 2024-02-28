using ESIN.Clinic.Application.Equipments.Queries;
using ESIN.Clinic.CrossCutting.Features.Equipments;
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
        var query = new GetEquipmentsQuery(EquipmentRepository);
        items = (await query.GetEquipmentsAsync()).AsQueryable();
    }
}