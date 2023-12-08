namespace ESIN.Clinic.Infrastructure.Entities;

public class Intervention
{
    public int Id { get; set; }
    public DateTime ReportDate { get; set; }
    public string? Observations { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public decimal? InvoiceValue { get; set; }
    public int InterventionType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int EmployeeId { get; set; }
    public int DeviceId { get; set; }
}