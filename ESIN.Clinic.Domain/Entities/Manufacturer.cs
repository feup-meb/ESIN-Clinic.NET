using ESIN.Clinic.Domain.Common;

namespace ESIN.Clinic.Domain.Entities;

public class Manufacturer : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public string? MobilePhoneNumber { get; set; }
    public required string Address { get; set; }
}