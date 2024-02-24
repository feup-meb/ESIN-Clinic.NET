namespace ESIN.Clinic.CrossCutting.Interventions;

public class GetInterventionsQueryResponse
{
    public int Id { get; set; }
    public DateTime ReportDate { get; set; }
    public string? Observations { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public double? InvoiceValue { get; set; }
    public string InterventionType { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string EmployeeName { get; set; } = string.Empty;
    public string EquipmentName { get; set; } = string.Empty;
}