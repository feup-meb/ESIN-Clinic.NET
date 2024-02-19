using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.Web.Components.Pages.Categories;

public partial class CategoryDetails
{
    [Parameter] public int? Id { get; set; }
    private Category item = new();
    
    protected override async Task OnInitializedAsync()
    {
        if (Id == null) 
            return;
        
        item = await GetCategoryByIdQuery.GetCategoryByIdAsync((int)Id);
    }
}