using ESIN.Clinic.Application.Manufacturers.Queries;
using ESIN.Clinic.CrossCutting.Features.Manufacturers;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Manufacturers;

public partial class ManufacturerDetails
{
    [Parameter] public int Id { get; set; }
    private GetManufacturerByIdQueryResponse? item;

    protected override async Task OnInitializedAsync()
    {
        var query = new GetManufacturerByIdQuery(ManufacturerRepository);
        item = await query.GetCategoryByIdAsync(Id);
    }
}