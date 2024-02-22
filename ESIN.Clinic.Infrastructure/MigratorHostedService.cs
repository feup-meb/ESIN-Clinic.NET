using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Domain.Enums;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ESIN.Clinic.Infrastructure;

public class MigratorHostedService(IServiceProvider serviceProvider, IHostEnvironment currentEnvironment) : IHostedService
{
    public Task StopAsync(CancellationToken cancellationToken) 
        => Task.CompletedTask;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();

        // Get the DbContext instance
        var clinicDbCtx = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
        await ApplyMigrations(clinicDbCtx, cancellationToken);
        await SeedClinicDatabase(clinicDbCtx, cancellationToken);
    }

    private async Task ApplyMigrations(ClinicDbContext dbCtx, CancellationToken cancellationToken)
    {
        if (dbCtx.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory" &&
            dbCtx.Database.ProviderName != "Microsoft.EntityFrameworkCore.Sqlite")
        {
            await dbCtx.Database.MigrateAsync(cancellationToken: cancellationToken);
        }
    }

    private async Task SeedClinicDatabase(ClinicDbContext dbCtx, CancellationToken cancellationToken)
    {
        SeedReferenceData(dbCtx);
        
        if (currentEnvironment.IsEnvironment("Testing"))
            SeedTestData(dbCtx);

        await dbCtx.SaveChangesAsync(cancellationToken);
    }

    private void SeedReferenceData(ClinicDbContext dbCtx)
    {
        AddUserRoles(dbCtx);
        AddCategories(dbCtx);
        AddHospitalUnits(dbCtx);
        AddManufacturers(dbCtx);
        dbCtx.SaveChanges();
        
        AddEmployees(dbCtx);
        AddEquipments(dbCtx);
        dbCtx.SaveChanges();
        
        AddInterventions(dbCtx);
        AddEquipmentAccesses(dbCtx);
    }

    private static void SeedTestData(ClinicDbContext dbCtx)
    {
        throw new NotImplementedException();
    }
    
    private static void AddUserRoles(ClinicDbContext dbCtx)
    {
        List<UserRole> roles =
        [
            new UserRole { Name = "Gestor" },
            new UserRole { Name = "Utilizador" }
        ];

        var dbRoles = dbCtx.UserRoles.IgnoreQueryFilters().ToList();
        
        foreach (UserRole role in roles)
        {
            UserRole? exitingRole = dbRoles
                .SingleOrDefault(x => x.Name == role.Name);
            
            if (exitingRole == null)
                dbCtx.UserRoles.Add(role);
        }
        
    }
    
    private static void AddCategories(ClinicDbContext dbCtx)
    {
        List<Category> categories =
        [
            new Category { Name = "Cirúrgico", Description = "Equipamentos utilizados em procedimentos invasivos." },
            new Category { Name = "Diagnóstico", Description = "Equipamentos utilizados para auxiliar no diagnóstico médico." },
            new Category { Name = "Monitorização", Description = "Equipamentos utilizados para monitorar sinais vitais." },
            new Category { Name = "Suporte", Description = "Equipamentos utilizados no suporte à vida." }
        ];

        var dbCategories = dbCtx.Categories.IgnoreQueryFilters().ToList();

        foreach (Category category in categories)
        {
            Category? exitingCategory = dbCategories
                .SingleOrDefault(x => x.Name == category.Name);
            
            if (exitingCategory == null)
                dbCtx.Categories.Add(category);
        }
    }
    
    private static void AddHospitalUnits(ClinicDbContext dbCtx)
    {
        List<HospitalUnit> hospitalUnits =
        [
            new HospitalUnit { Name = "Urgência" },
            new HospitalUnit { Name = "Unidade de Cuidados Intensivos" },
            new HospitalUnit { Name = "Centro Cirúrgico" },
            new HospitalUnit { Name = "Radiologia", Room = "Sala 1" }
        ];

        var dbHospitalUnits = dbCtx.HospitalUnits.IgnoreQueryFilters().ToList();

        foreach (HospitalUnit hospitalUnit in hospitalUnits)
        {
            HospitalUnit? exitingHospitalUnit = dbHospitalUnits
                .SingleOrDefault(x => x.Name == hospitalUnit.Name);
            
            if (exitingHospitalUnit == null)
                dbCtx.HospitalUnits.Add(hospitalUnit);
        }
    }

    private static void AddManufacturers(ClinicDbContext dbCtx)
    {
        List<Manufacturer> manufacturers =
        [
            new Manufacturer { Name = "GE Medical", Email = "contacto@gemedical.com", PhoneNumber = "225 522 100", MobilePhoneNumber = "910 690 782", Address = "Rua dos Aflitos, 245" },
            new Manufacturer { Name = "Shimadzu", Email = "contacto@shimadzu.com", PhoneNumber = "225 522 101", MobilePhoneNumber = "910 690 785", Address = "Rua das Palmeiras, 1250" },
            new Manufacturer { Name = "Philips Medical", Email = "contacto@philipsmedical.com", PhoneNumber = "225 522 102", MobilePhoneNumber = "910 690 784", Address = "Avenida Dom Manuel, s/ número" },
            new Manufacturer { Name = "Nihon Kohden", Email = "contacto@nihonkohden.com", PhoneNumber = "225 522 103", MobilePhoneNumber = "910 690 783", Address = "Avenida dos Caires, 13" },
            new Manufacturer { Name = "AlfaMed", Email = "contacto@alfamed.com", PhoneNumber = "225 522 104", MobilePhoneNumber = "910 690 781", Address = "Avenida França, 578" },
            new Manufacturer { Name = "Intermed", Email = "contacto@intermed.com", PhoneNumber = "225 522 105", MobilePhoneNumber = "910 690 780", Address = "Avenida dos Descobrimentos, 264" }
        ];

        var dbManufacturers = dbCtx.Manufacturers.IgnoreQueryFilters().ToList();

        foreach (Manufacturer manufacturer in manufacturers)
        {
            Manufacturer? exitingManufacturer = dbManufacturers
                .SingleOrDefault(x => x.Name == manufacturer.Name);
            
            if (exitingManufacturer == null)
                dbCtx.Manufacturers.Add(manufacturer);
        }
    }

    private static void AddEmployees(ClinicDbContext dbCtx)
    {
        List<Employee> employees =
        [
            new Employee { Name = "Leandro", HospitalUnitId = 1, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 1), EmployeeNumber = "up201802127", Password = "735d7507b5410ee9b3dd1ea93bb60d31df0d2b1a", UserRoleId = 1, UserRole = dbCtx.UserRoles.First(x => x.Id == 1) },
            new Employee { Name = "Helena", HospitalUnitId = 1, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 1), EmployeeNumber = "up201405139", Password = "1c7ab2a24cdbcff89da653d7abf1ac856a8e530f", UserRoleId = 1, UserRole = dbCtx.UserRoles.First(x => x.Id == 1) },
            new Employee { Name = "John Doe", Address = "Baker Street", HospitalUnitId = 2, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 2), EmployeeNumber = "up201812345", Password = "5156ef0b70aa95a7290689040e046e4415841155", UserRoleId = 2, UserRole = dbCtx.UserRoles.First(x => x.Id == 2) }
        ];

        var dbEmployees = dbCtx.Employees.IgnoreQueryFilters().ToList();
        
        foreach (Employee employee in employees)
        {
            Employee? exitingEmployee = dbEmployees
                .SingleOrDefault(x => x.Name == employee.Name &&
                                      x.EmployeeNumber == employee.EmployeeNumber);
            
            if (exitingEmployee == null)
                dbCtx.Employees.Add(employee);
        }
    }
    
    private static void AddEquipments(ClinicDbContext dbCtx)
    {
        List<Equipment> equipments =
        [
            new Equipment { Name = "Aparelho de anestesia", Model = "Aespire 7900", SerialNumber = "ANCU00189", Description = "Aparelho com utilização de drogas para anestesia e ventilação pulmonar.", ManufacturerId = 1, Manufacturer = dbCtx.Manufacturers.First(x => x.Id == 1), CategoryId = 1, Category = dbCtx.Categories.First(x => x.Id == 1), AcquisitionDate = new DateTime(2014, 05, 26), WarrantyDate = new DateTime(2015, 05, 26), Price = 100500, IsActive = true, HospitalUnitId = 3, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 3) },
            new Equipment { Name = "Aparelho de Raios-X móvel", Model = "Mux-200 MobileArt EVO", SerialNumber = "0362Z16809", Description = "Aparelho móvel para aquisição de imagem.", ManufacturerId = 2, Manufacturer = dbCtx.Manufacturers.First(x => x.Id == 2), CategoryId = 2, Category = dbCtx.Categories.First(x => x.Id == 2), AcquisitionDate = new DateTime(2008, 06, 20), WarrantyDate = new DateTime(2009, 06, 20), Price = 78000, IsActive = true, HospitalUnitId = 4, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 4) },
            new Equipment { Name = "Monitor multiparâmetro", Model = "Cardiocap/5", SerialNumber = "6169749", Description = "Monitor de sinais vitais para anestesia GE.", ManufacturerId = 1, Manufacturer = dbCtx.Manufacturers.First(x => x.Id == 1), CategoryId = 3, Category = dbCtx.Categories.First(x => x.Id == 3), AcquisitionDate = new DateTime(2007, 02, 12), WarrantyDate = new DateTime(2008, 02, 12), Price = 20000, IsActive = true, HospitalUnitId = 3, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 3) },
            new Equipment { Name = "Monitor multiparâmetro", Model = "Intellivue MP 20", SerialNumber = "DE 6222577", Description = "Monitor de sinais vitais com eletro cardiógrafo.", ManufacturerId = 3, Manufacturer = dbCtx.Manufacturers.First(x => x.Id == 3), CategoryId = 3, Category = dbCtx.Categories.First(x => x.Id == 3), AcquisitionDate = new DateTime(2007, 02, 01), WarrantyDate = new DateTime(2008, 02, 01), Price = 10000, IsActive = false, HospitalUnitId = 2, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 2) },
            new Equipment { Name = "Monitor multiparâmetro", Model = "BSM-3763", SerialNumber = "2826", Description = "Monitor de sinais vitais para leitos de UCI.", ManufacturerId = 4, Manufacturer = dbCtx.Manufacturers.First(x => x.Id == 4), CategoryId = 3, Category = dbCtx.Categories.First(x => x.Id == 3), AcquisitionDate = new DateTime(2015, 12, 18), WarrantyDate = new DateTime(2016, 12, 18), Price = 25000, IsActive = true, HospitalUnitId = 2, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 2) },
            new Equipment { Name = "Monitor multiparâmetro", Model = "Vita 600", SerialNumber = "V600600020", Description = "Monitor de saturação e frequência cardíaca.", ManufacturerId = 5, Manufacturer = dbCtx.Manufacturers.First(x => x.Id == 5), CategoryId = 3, Category = dbCtx.Categories.First(x => x.Id == 3), AcquisitionDate = new DateTime(2016, 01, 21), WarrantyDate = new DateTime(2017, 01, 21), Price = 8000, IsActive = true, HospitalUnitId = 1, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 1) },
            new Equipment { Name = "Ventilador pulmonar", Model = "iX5", SerialNumber = "IX5-2012-09-00165", Description = "Aparelho que realiza as funções respiratórias pelo utente incapacitado.", ManufacturerId = 6, Manufacturer = dbCtx.Manufacturers.First(x => x.Id == 6), CategoryId = 4, Category = dbCtx.Categories.First(x => x.Id == 4), AcquisitionDate = new DateTime(2013, 12, 01), WarrantyDate = new DateTime(2014, 12, 01), Price = 56000, IsActive = true, HospitalUnitId = 2, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 2) }
        ];

        var dbEquipments = dbCtx.Equipments.IgnoreQueryFilters().ToList();
        
        foreach (Equipment equipment in equipments)
        {
            Equipment? exitingEquipment = dbEquipments
                .SingleOrDefault(x => x.Model == equipment.Model &&
                                      x.SerialNumber == equipment.SerialNumber &&
                                      x.ManufacturerId == equipment.ManufacturerId);
            
            if (exitingEquipment == null)
                dbCtx.Equipments.Add(equipment);
        }
    }
    
    private static void AddInterventions(ClinicDbContext dbCtx)
    {
        List<Intervention> interventions =
        [
            new Intervention
            {
                ReportDate = new DateTime(2017, 12, 20),
                Observations = "Monitor apresenta falha na medição de ECG.",
                EvaluationDate = new DateTime(2017, 12, 27), 
                InvoiceValue = 5000,
                InterventionType = InterventionType.Corrective, 
                StartDate = new DateTime(2018, 01, 10),
                EndDate = new DateTime(2018, 01, 23), 
                EmployeeId = 3, 
                EquipmentId = 4
            }
        ];

        var dbInterventions = dbCtx.Interventions.IgnoreQueryFilters().ToList();

        foreach (Intervention intervention in interventions)
        {
            Intervention? exitingInterventions = dbInterventions
                .SingleOrDefault(x => x.ReportDate == intervention.ReportDate &&
                                      x.EmployeeId == intervention.EmployeeId &&
                                      x.EquipmentId == intervention.EquipmentId &&
                                      x.InterventionType == intervention.InterventionType);
            
            if (exitingInterventions == null)
                dbCtx.Interventions.Add(intervention);
        }
    }
    
    private static void AddEquipmentAccesses(ClinicDbContext dbCtx)
    {
        List<EquipmentAccess> equipmentAccesses =
        [
            new EquipmentAccess { EmployeeId = 1, Employee = dbCtx.Employees.First(x => x.Id == 1), EquipmentId = 1, Equipment = dbCtx.Equipments.First(x => x.Id == 1) },
            new EquipmentAccess { EmployeeId = 1, Employee = dbCtx.Employees.First(x => x.Id == 1), EquipmentId = 2, Equipment = dbCtx.Equipments.First(x => x.Id == 2) },
            new EquipmentAccess { EmployeeId = 2, Employee = dbCtx.Employees.First(x => x.Id == 2), EquipmentId = 3, Equipment = dbCtx.Equipments.First(x => x.Id == 3) },
            new EquipmentAccess { EmployeeId = 2, Employee = dbCtx.Employees.First(x => x.Id == 2), EquipmentId = 4, Equipment = dbCtx.Equipments.First(x => x.Id == 4) },
            new EquipmentAccess { EmployeeId = 3, Employee = dbCtx.Employees.First(x => x.Id == 3), EquipmentId = 1, Equipment = dbCtx.Equipments.First(x => x.Id == 1) },
            new EquipmentAccess { EmployeeId = 3, Employee = dbCtx.Employees.First(x => x.Id == 3), EquipmentId = 3, Equipment = dbCtx.Equipments.First(x => x.Id == 3) }
        ];

        var dbInterventions = dbCtx.EquipmentAccesses.IgnoreQueryFilters().ToList();

        foreach (EquipmentAccess equipmentAccess in equipmentAccesses)
        {
            EquipmentAccess? exitingEquipmentAccess = dbInterventions
                .SingleOrDefault(x => x.EmployeeId == equipmentAccess.EmployeeId &&
                                      x.EquipmentId == equipmentAccess.EquipmentId);
            
            if (exitingEquipmentAccess == null)
                dbCtx.EquipmentAccesses.Add(equipmentAccess);
        }
    }
}