namespace ESIN.Clinic.Domain.Entities;

public class EquipmentAccess
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public required Employee Employee { get; set; }
    public int EquipmentId { get; set; }
    public required Equipment Equipment { get; set; }
}