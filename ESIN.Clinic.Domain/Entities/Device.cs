using ESIN.Clinic.Domain.Common;

namespace ESIN.Clinic.Domain.Entities;

public sealed class Device : BaseEntity
{
    public string SerialNumber { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string? Description { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public DateTime WarrantyDate { get; set; }
    public double? Price { get; set; }
    public bool IsActive { get; set; }
    
    public int ManufacturerId { get; set; }
    public int DeviceCategoryId { get; set; }
    public int HospitalUnitId { get; set; }
}