using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.CrossCutting.Categories;

public class GetCategoriesQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }= string.Empty;
}

