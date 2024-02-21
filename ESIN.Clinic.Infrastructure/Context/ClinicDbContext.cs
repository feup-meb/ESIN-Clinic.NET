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
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
    }
}