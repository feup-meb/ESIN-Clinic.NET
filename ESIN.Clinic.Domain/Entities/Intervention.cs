using ESIN.Clinic.Domain.Common;
using ESIN.Clinic.Domain.Enums;

namespace ESIN.Clinic.Domain.Entities;

public class Intervention : BaseEntity
{
    public required DateTime ReportDate { get; set; }
    public string? Observations { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public double? InvoiceValue { get; set; }
    public required InterventionType InterventionType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int EmployeeId { get; set; }
    public required Employee Employee { get; set; }
    public int EquipmentId { get; set; }
    public required Equipment Equipment { get; set; }
}