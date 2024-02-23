using ESIN.Clinic.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Categories;

public partial class CategoryDetails
{
    [Parameter] public int? Id { get; set; }
    private Category? item;
    
    protected override async Task OnInitializedAsync()
    {
        if (Id == null) 
            return;
        
        item = await GetCategoryByIdQuery.GetCategoryByIdAsync((int)Id);
    }
}