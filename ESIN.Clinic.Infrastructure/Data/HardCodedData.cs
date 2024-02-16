using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Domain.Enums;

namespace ESIN.Clinic.Infrastructure.Data;

public class HardCodedData : IClinicContext
{
    public List<HospitalUnit> HospitalUnits() =>
    [
        new HospitalUnit { Id = 1, Name = "Urgência" },
        new HospitalUnit { Id = 2, Name = "Unidade de Cuidados Intensivos" },
        new HospitalUnit { Id = 3, Name = "Centro Cirúrgico" },
        new HospitalUnit { Id = 4, Name = "Radiologia", Room = "Sala 1" }
    ];

    public List<UserRole> UserRoles() =>
    [
        new UserRole { Id = 1, Name = "Gestor" },
        new UserRole { Id = 2, Name = "Utilizador" }
    ];

    public List<Employee> Employees() =>
    [
        new Employee { Id = 1, Name = "Leandro", HospitalUnitId = 1, EmployeeNumber = "up201802127", Password = "735d7507b5410ee9b3dd1ea93bb60d31df0d2b1a", UserTypeId = 1 },
        new Employee { Id = 2, Name = "Helena", HospitalUnitId = 1, EmployeeNumber = "up201405139", Password = "1c7ab2a24cdbcff89da653d7abf1ac856a8e530f", UserTypeId = 1 },
        new Employee { Id = 3, Name = "John Doe", Address = "Baker Street", HospitalUnitId = 2, EmployeeNumber = "up201812345", Password = "5156ef0b70aa95a7290689040e046e4415841155", UserTypeId = 2 }
    ];
    
    public List<Manufacturer> Manufacturers() =>
    [
        new Manufacturer { Id = 1, Name = "GE Medical", Email = "contacto@gemedical.com", PhoneNumber = "225 522 100", MobilePhoneNumber = "910 690 782", Address = "Rua dos Aflitos, 245" },
        new Manufacturer { Id = 2, Name = "Shimadzu", Email = "contacto@shimadzu.com", PhoneNumber = "225 522 101", MobilePhoneNumber = "910 690 785", Address = "Rua das Palmeiras, 1250" },
        new Manufacturer { Id = 3, Name = "Philips Medical", Email = "contacto@philipsmedical.com", PhoneNumber = "225 522 102", MobilePhoneNumber = "910 690 784", Address = "Avenida Dom Manuel, s/ número" },
        new Manufacturer { Id = 4, Name = "Nihon Kohden", Email = "contacto@nihonkohden.com", PhoneNumber = "225 522 103", MobilePhoneNumber = "910 690 783", Address = "Avenida dos Caires, 13" },
        new Manufacturer { Id = 5, Name = "AlfaMed", Email = "contacto@alfamed.com", PhoneNumber = "225 522 104", MobilePhoneNumber = "910 690 781", Address = "Avenida França, 578" },
        new Manufacturer { Id = 6, Name = "Intermed", Email = "contacto@intermed.com", PhoneNumber = "225 522 105", MobilePhoneNumber = "910 690 780", Address = "Avenida dos Descobrimentos, 264" }
    ];
    
    public List<Category> Categories() =>
    [
        new Category { Id = 1, Name = "Cirúrgico", Description = "Equipamentos utilizados em procedimentos invasivos." },
        new Category { Id = 2, Name = "Diagnóstico", Description = "Equipamentos utilizados para auxiliar no diagnóstico médico." },
        new Category { Id = 3, Name = "Monitorização", Description = "Equipamentos utilizados para monitorar sinais vitais." },
        new Category { Id = 4, Name = "Suporte", Description = "Equipamentos utilizados no suporte à vida." }
    ];
    
    public List<Equipment> Equipments() =>
    [
        new Equipment { Id = 1, Name = "Aparelho de anestesia", Model = "Aespire 7900", SerialNumber = "ANCU00189", Description = "Aparelho com utilização de drogas para anestesia e ventilação pulmonar.", ManufacturerId = 1, Manufacturer = Manufacturers().Find(x => x.Id == 1)!, CategoryId = 1, Category = Categories().Find(x => x.Id == 1)!, AcquisitionDate = new DateOnly(2014, 05, 26), WarrantyDate = new DateOnly(2015, 05, 26), Price = 100500, IsActive = true, HospitalUnitId = 3, HospitalUnit = HospitalUnits().Find(x => x.Id == 3)! },
        new Equipment { Id = 2, Name = "Aparelho de Raios-X móvel", Model = "Mux-200 MobileArt EVO", SerialNumber = "0362Z16809", Description = "Aparelho móvel para aquisição de imagem.", ManufacturerId = 2, Manufacturer = Manufacturers().Find(x => x.Id == 2)!, CategoryId = 2, Category = Categories().Find(x => x.Id == 2)!, AcquisitionDate = new DateOnly(2008, 06, 20), WarrantyDate = new DateOnly(2009, 06, 20), Price = 78000, IsActive = true, HospitalUnitId = 4, HospitalUnit = HospitalUnits().Find(x => x.Id == 4)! },
        new Equipment { Id = 3, Name = "Monitor multiparâmetro", Model = "Cardiocap/5", SerialNumber = "6169749", Description = "Monitor de sinais vitais para anestesia GE.", ManufacturerId = 1, Manufacturer = Manufacturers().Find(x => x.Id == 1)!, CategoryId = 3, Category = Categories().Find(x => x.Id == 3)!, AcquisitionDate = new DateOnly(2007, 02, 12), WarrantyDate = new DateOnly(2008, 02, 12), Price = 20000, IsActive = true, HospitalUnitId = 3, HospitalUnit = HospitalUnits().Find(x => x.Id == 3)! },
        new Equipment { Id = 4, Name = "Monitor multiparâmetro", Model = "Intellivue MP 20", SerialNumber = "DE 6222577", Description = "Monitor de sinais vitais com eletro cardiógrafo.", ManufacturerId = 3, Manufacturer = Manufacturers().Find(x => x.Id == 3)!, CategoryId = 3, Category = Categories().Find(x => x.Id == 3)!, AcquisitionDate = new DateOnly(2007, 02, 01), WarrantyDate = new DateOnly(2008, 02, 01), Price = 10000, IsActive = false, HospitalUnitId = 2, HospitalUnit = HospitalUnits().Find(x => x.Id == 2)! },
        new Equipment { Id = 5, Name = "Monitor multiparâmetro", Model = "BSM-3763", SerialNumber = "2826", Description = "Monitor de sinais vitais para leitos de UCI.", ManufacturerId = 4, Manufacturer = Manufacturers().Find(x => x.Id == 4)!, CategoryId = 3, Category = Categories().Find(x => x.Id == 3)!, AcquisitionDate = new DateOnly(2015, 12, 18), WarrantyDate = new DateOnly(2016, 12, 18), Price = 25000, IsActive = true, HospitalUnitId = 2, HospitalUnit = HospitalUnits().Find(x => x.Id == 2)! },
        new Equipment { Id = 6, Name = "Monitor multiparâmetro", Model = "Vita 600", SerialNumber = "V600600020", Description = "Monitor de saturação e frequência cardíaca.", ManufacturerId = 5, Manufacturer = Manufacturers().Find(x => x.Id == 5)!, CategoryId = 3, Category = Categories().Find(x => x.Id == 3)!, AcquisitionDate = new DateOnly(2016, 01, 21), WarrantyDate = new DateOnly(2017, 01, 21), Price = 8000, IsActive = true, HospitalUnitId = 1, HospitalUnit = HospitalUnits().Find(x => x.Id == 1)! },
        new Equipment { Id = 7, Name = "Ventilador pulmonar", Model = "iX5", SerialNumber = "IX5-2012-09-00165", Description = "Aparelho que realiza as funções respiratórias pelo utente incapacitado.", ManufacturerId = 6, Manufacturer = Manufacturers().Find(x => x.Id == 6)!, CategoryId = 4, Category = Categories().Find(x => x.Id == 4)!, AcquisitionDate = new DateOnly(2013, 12, 01), WarrantyDate = new DateOnly(2014, 12, 01), Price = 56000, IsActive = true, HospitalUnitId = 2, HospitalUnit = HospitalUnits().Find(x => x.Id == 2)! }
    ];

    public List<Intervention> Interventions() =>
    [
        new Intervention
        {
            Id = 1, 
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

    public List<EquipmentAccess> DevicesAccesses() =>
    [
        new EquipmentAccess { Id = 1, EmployeeId = 1, Employee = Employees().Find(x => x.Id == 1)!, EquipmentId = 1, Equipment = Equipments().Find(x => x.Id == 1)! },
        new EquipmentAccess { Id = 2, EmployeeId = 1, Employee = Employees().Find(x => x.Id == 1)!, EquipmentId = 2, Equipment = Equipments().Find(x => x.Id == 2)! },
        new EquipmentAccess { Id = 3, EmployeeId = 2, Employee = Employees().Find(x => x.Id == 2)!, EquipmentId = 3, Equipment = Equipments().Find(x => x.Id == 3)! },
        new EquipmentAccess { Id = 4, EmployeeId = 2, Employee = Employees().Find(x => x.Id == 2)!, EquipmentId = 4, Equipment = Equipments().Find(x => x.Id == 4)! },
        new EquipmentAccess { Id = 5, EmployeeId = 3, Employee = Employees().Find(x => x.Id == 3)!, EquipmentId = 1, Equipment = Equipments().Find(x => x.Id == 1)! },
        new EquipmentAccess { Id = 6, EmployeeId = 3, Employee = Employees().Find(x => x.Id == 3)!, EquipmentId = 3, Equipment = Equipments().Find(x => x.Id == 3)! }
    ];
}