using ESIN.Clinic.CrossCutting.Categories;
using Microsoft.AspNetCore.Components;

namespace ESIN.Clinic.WebApp.Components.Pages.Categories;

public partial class CategoryDetails
{
    [Parameter] public int? Id { get; set; }
    private GetCategoryByIdQueryResponse? item;
    
    protected override async Task OnInitializedAsync()
    {
        if (Id == null) 
            return;

        var http = new HttpClient();
        
        item = await http.GetFromJsonAsync<GetCategoryByIdQueryResponse>($"http://localhost:5240/categories/{Id}");
    }
}