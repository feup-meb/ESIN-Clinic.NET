using ESIN.Clinic.Domain.Common;

namespace ESIN.Clinic.Domain.Entities;

public sealed class Category : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}