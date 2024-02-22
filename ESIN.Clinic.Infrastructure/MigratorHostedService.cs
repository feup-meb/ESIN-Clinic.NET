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
        // AddEquipmentAccesses(dbCtx);
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

        var roleIds = roles.Select(x => x.Id);
        var rolesAlreadyCreated = dbCtx.UserRoles
            .IgnoreQueryFilters()
            .Where(x => roleIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var rolesToCreate = roles
            .Where(x => !rolesAlreadyCreated.Contains(x.Id))
            .ToList();

        if (rolesToCreate.Any())
            dbCtx.UserRoles.AddRange(rolesToCreate);
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

        var categoryIds = categories.Select(x => x.Id);
        var categoriesAlreadyCreated = dbCtx.Categories
            .IgnoreQueryFilters()
            .Where(x => categoryIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var categoriesToCreate = categories
            .Where(x => !categoriesAlreadyCreated.Contains(x.Id))
            .ToList();

        if (categoriesToCreate.Any())
            dbCtx.Categories.AddRange(categoriesToCreate);
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

        var hospitalUnitIds = hospitalUnits.Select(x => x.Id);
        var hospitalUnitsAlreadyCreated = dbCtx.HospitalUnits
            .IgnoreQueryFilters()
            .Where(x => hospitalUnitIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var hospitalUnitsToCreate = hospitalUnits
            .Where(x => !hospitalUnitsAlreadyCreated.Contains(x.Id))
            .ToList();

        if (hospitalUnitsToCreate.Any())
            dbCtx.HospitalUnits.AddRange(hospitalUnitsToCreate);
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

        var manufacturerIds = manufacturers.Select(x => x.Id);
        var manufacturersAlreadyCreated = dbCtx.Manufacturers
            .IgnoreQueryFilters()
            .Where(x => manufacturerIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var manufacturersToCreate = manufacturers
            .Where(x => !manufacturersAlreadyCreated.Contains(x.Id))
            .ToList();

        if (manufacturersToCreate.Any())
            dbCtx.Manufacturers.AddRange(manufacturersToCreate);
    }

    private static void AddEmployees(ClinicDbContext dbCtx)
    {
        List<Employee> employees =
        [
            new Employee { Name = "Leandro", HospitalUnitId = 1, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 1), EmployeeNumber = "up201802127", Password = "735d7507b5410ee9b3dd1ea93bb60d31df0d2b1a", UserRoleId = 1, UserRole = dbCtx.UserRoles.First(x => x.Id == 1) },
            new Employee { Name = "Helena", HospitalUnitId = 1, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 1), EmployeeNumber = "up201405139", Password = "1c7ab2a24cdbcff89da653d7abf1ac856a8e530f", UserRoleId = 1, UserRole = dbCtx.UserRoles.First(x => x.Id == 1) },
            new Employee { Name = "John Doe", Address = "Baker Street", HospitalUnitId = 2, HospitalUnit = dbCtx.HospitalUnits.First(x => x.Id == 2), EmployeeNumber = "up201812345", Password = "5156ef0b70aa95a7290689040e046e4415841155", UserRoleId = 2, UserRole = dbCtx.UserRoles.First(x => x.Id == 2) }
        ];

        var employeeIds = employees.Select(x => x.Id);
        var employeesAlreadyCreated = dbCtx.Employees
            .IgnoreQueryFilters()
            .Where(x => employeeIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var employeesToCreate = employees
            .Where(x => !employeesAlreadyCreated.Contains(x.Id))
            .ToList();

        if (employeesToCreate.Any())
            dbCtx.Employees.AddRange(employeesToCreate);
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

        var equipmentIds = equipments.Select(x => x.Id);
        var equipmentsAlreadyCreated = dbCtx.Equipments
            .IgnoreQueryFilters()
            .Where(x => equipmentIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var equipmentsToCreate = equipments
            .Where(x => !equipmentsAlreadyCreated.Contains(x.Id))
            .ToList();

        if (equipmentsToCreate.Any())
            dbCtx.Equipments.AddRange(equipmentsToCreate);
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

        var interventionIds = interventions.Select(x => x.Id);
        var interventionsAlreadyCreated = dbCtx.Interventions
            .IgnoreQueryFilters()
            .Where(x => interventionIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var interventionsToCreate = interventions
            .Where(x => !interventionsAlreadyCreated.Contains(x.Id))
            .ToList();

        if (interventionsToCreate.Any())
            dbCtx.Interventions.AddRange(interventionsToCreate);
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
    
        var equipmentAccessIds = equipmentAccesses.Select(x => x.Id);
        var equipmentAccessesAlreadyCreated = dbCtx.EquipmentAccesses
            .IgnoreQueryFilters()
            .Where(x => equipmentAccessIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToList();
        var equipmentAccessesToCreate = equipmentAccesses
            .Where(x => !equipmentAccessesAlreadyCreated.Contains(x.Id))
            .ToList();
    
        if (equipmentAccessesToCreate.Any())
            dbCtx.EquipmentAccesses.AddRange(equipmentAccessesToCreate);
    }
}