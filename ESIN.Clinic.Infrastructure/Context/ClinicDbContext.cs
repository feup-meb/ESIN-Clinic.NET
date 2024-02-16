using ESIN.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Context;

public class ClinicDbContext : DbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
    : base(options)
    {
    }

    public DbSet<Intervention> Interventions { get; set; }
    public DbSet<HospitalUnit> HospitalUnits { get; set; }
    // public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Category> Categories { get; set; }
    // public DbSet<Manufacturer> Manufacturers { get; set; }
    // public DbSet<EquipmentAccess> EquipmentAccesses { get; set; }
    // public DbSet<UserType> UserTypes { get; set; }
    // public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
    }
}