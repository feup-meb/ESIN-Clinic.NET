using ESIN.Clinic.Application.Categories.Queries;
using ESIN.Clinic.CrossCutting.Features.Categories;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Categories;

public partial class CategoryDetails
{
    [Parameter] public int Id { get; set; }
    private GetCategoryByIdQueryResponse? item;
    
    protected override async Task OnInitializedAsync()
    {
        var query = new GetCategoryByIdQuery(CategoryRepository);
        item = await query.GetCategoryByIdAsync(Id);
    }
}