using ESIN.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESIN.Clinic.Infrastructure.Configurations;

public class EquipmentAccessConfigurations : IEntityTypeConfiguration<EquipmentAccess>
{
    public void Configure(EntityTypeBuilder<EquipmentAccess> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Equipment).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Employee).WithMany().OnDelete(DeleteBehavior.NoAction);
    }
}