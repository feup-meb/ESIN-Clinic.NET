namespace ESIN.Clinic.Domain.Entities;

public class HospitalUnit
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Room { get; set; }
}