using ESIN.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESIN.Clinic.Infrastructure.Configurations;

public class HospitalUnitConfigurations : IEntityTypeConfiguration<HospitalUnit>
{
    public void Configure(EntityTypeBuilder<HospitalUnit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Room).HasMaxLength(50);
    }
}