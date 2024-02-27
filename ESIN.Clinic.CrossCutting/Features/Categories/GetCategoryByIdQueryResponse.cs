namespace ESIN.Clinic.CrossCutting.Features.Categories;

public class GetCategoryByIdQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }= string.Empty;
}