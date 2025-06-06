using ESIN.Clinic.Domain.Common;

namespace ESIN.Clinic.Domain.Entities;

public class HospitalUnit : BaseEntity
{
    public required string Name { get; set; }
    public string? Room { get; set; }
}