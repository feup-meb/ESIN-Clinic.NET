namespace ESIN.Clinic.CrossCutting.Equipments;

public class GetEquipmentByIdQueryResponse
{
    public int Id { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime AcquisitionDate { get; set; }
    public DateTime WarrantyDate { get; set; }
    public double? Price { get; set; }
    public bool IsActive { get; set; }
    
    public string Manufacturer { get; set; }
    public string Category { get; set; }
    public string HospitalUnit { get; set; }
}