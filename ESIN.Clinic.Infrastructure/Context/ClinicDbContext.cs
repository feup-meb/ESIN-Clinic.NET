using ESIN.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Context;

public class ClinicDbContext : DbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
    : base(options)
    {
    }

    public DbSet<DeviceCategory> DeviceCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
    }
}