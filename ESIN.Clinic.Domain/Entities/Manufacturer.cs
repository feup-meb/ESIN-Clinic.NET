namespace ESIN.Clinic.Domain.Entities;

public class Manufacturer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string MobilePhoneNumber { get; set; }
    public required string Address { get; set; }
}