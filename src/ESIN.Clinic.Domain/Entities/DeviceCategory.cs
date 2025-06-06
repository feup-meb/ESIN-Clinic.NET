using ESIN.Clinic.Domain.Common;

namespace ESIN.Clinic.Domain.Entities;

public class DeviceCategory : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}