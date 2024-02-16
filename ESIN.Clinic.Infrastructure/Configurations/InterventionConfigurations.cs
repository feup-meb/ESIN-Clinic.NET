using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESIN.Clinic.Infrastructure.Configurations;

public class InterventionConfigurations : IEntityTypeConfiguration<Intervention>
{
    public void Configure(EntityTypeBuilder<Intervention> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ReportDate).IsRequired();
        builder.Property(x => x.EvaluationDate);
        builder.Property(x => x.StartDate);
        builder.Property(x => x.EndDate);
        builder.Property(x => x.InterventionType).IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (InterventionType)Enum.Parse(typeof(InterventionType), v));
        builder.Property(x => x.InvoiceValue).HasPrecision(7, 2);
        builder.Property(x => x.Observations);

        builder.HasOne(x=>x.Employee);
        builder.HasOne(x=>x.Equipment);
    }
}