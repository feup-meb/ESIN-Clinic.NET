using System.Security.Cryptography;

namespace ESIN.Clinic.Infrastructure.Entities;

public class Device
{
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string? Description { get; set; }
    public DateOnly AcquisitionDate { get; set; }
    public DateOnly WarrantyDate { get; set; }
    public double Price { get; set; }
    public bool IsActive { get; set; }
    
    public int ManufacturerId { get; set; }
    public int DeviceCategoryId { get; set; }
    public int HospitalUnitId { get; set; }
}