using ESIN.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESIN.Clinic.Infrastructure.Configurations;

public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.EmployeeNumber).HasMaxLength(12).IsRequired();
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.Address).IsRequired();
        builder.Property(x => x.UserRole).IsRequired();
        builder.HasOne(x => x.UserRole);
    }
}