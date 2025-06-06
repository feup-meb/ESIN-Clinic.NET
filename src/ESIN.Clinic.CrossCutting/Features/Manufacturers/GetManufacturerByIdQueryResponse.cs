namespace ESIN.Clinic.CrossCutting.Features.Manufacturers;

public class GetManufacturerByIdQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? MobilePhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}