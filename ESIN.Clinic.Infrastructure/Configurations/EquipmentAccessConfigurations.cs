using ESIN.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESIN.Clinic.Infrastructure.Configurations;

public class EquipmentAccessConfigurations : IEntityTypeConfiguration<EquipmentAccess>
{
    public void Configure(EntityTypeBuilder<EquipmentAccess> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Equipment);
        builder.HasOne(x => x.Employee);
    }
}