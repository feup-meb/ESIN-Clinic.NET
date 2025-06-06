using ESIN.Clinic.Domain.Common;

namespace ESIN.Clinic.Domain.Entities;

public class UserRole : BaseEntity
{
    public required string Name { get; set; }
}