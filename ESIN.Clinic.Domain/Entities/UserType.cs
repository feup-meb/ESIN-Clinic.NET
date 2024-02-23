using ESIN.Clinic.Domain.Common;

namespace ESIN.Clinic.Domain.Entities;

public class UserType : BaseEntity
{
    public required string Name { get; set; }
}