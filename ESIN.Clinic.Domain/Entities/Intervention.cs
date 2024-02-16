using ESIN.Clinic.Domain.Enums;

namespace ESIN.Clinic.Domain.Entities;

public class Intervention
{
    public int Id { get; set; }
    public DateTime ReportDate { get; set; }
    public string? Observations { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public double? InvoiceValue { get; set; }
    public InterventionType InterventionType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }
}