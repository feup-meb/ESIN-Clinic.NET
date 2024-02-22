namespace ESIN.Clinic.Domain.Entities;

public class Equipment
{
    public int Id { get; set; }
    public required string SerialNumber { get; set; }
    public required string Name { get; set; }
    public required string Model { get; set; }
    public string? Description { get; set; }
    public required DateTime AcquisitionDate { get; set; }
    public required DateTime WarrantyDate { get; set; }
    public double? Price { get; set; }
    public bool IsActive { get; set; }
    
    public int ManufacturerId { get; set; }
    public required Manufacturer Manufacturer { get; set; }
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    public int HospitalUnitId { get; set; }
    public required HospitalUnit HospitalUnit { get; set; }
}