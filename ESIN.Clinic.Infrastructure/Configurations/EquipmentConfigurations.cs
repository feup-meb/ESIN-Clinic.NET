using ESIN.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESIN.Clinic.Infrastructure.Configurations;

public class EquipmentConfigurations : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SerialNumber).IsRequired();
        builder.HasIndex(x => x.SerialNumber).IsUnique();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Model).IsRequired();
        builder.Property(x => x.Description);
        builder.Property(x => x.AcquisitionDate).IsRequired();
        builder.Property(x => x.WarrantyDate).IsRequired();
        builder.Property(x => x.Price).HasPrecision(10, 2);
        builder.Property(x => x.IsActive);

        builder.HasOne(x => x.Manufacturer);
        builder.HasOne(x => x.Category);
        builder.HasOne(x => x.HospitalUnit);
    }
}