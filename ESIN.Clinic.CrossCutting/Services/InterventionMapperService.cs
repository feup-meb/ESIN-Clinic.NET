using ESIN.Clinic.CrossCutting.Interventions;
using ESIN.Clinic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ESIN.Clinic.CrossCutting.Services;

public static class InterventionMapperService
{
    public static List<GetInterventionsQueryResponse> ToResponse(List<Intervention> interventions)
    {
        if(interventions.IsNullOrEmpty())
            return [];

        List<GetInterventionsQueryResponse> response = [];
        interventions.ToList().ForEach(x => response.Add(new GetInterventionsQueryResponse
        {
            Id = x.Id,
            ReportDate = x.ReportDate,
            Observations = x.Observations,
            EvaluationDate = x.EvaluationDate,
            InvoiceValue = x.InvoiceValue,
            InterventionType = x.InterventionType.ToString(),
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            EmployeeName = x.Employee.Name,
            EquipmentName = x.Equipment.Name
        }));

        return response;
    }
    
    public static GetInterventionByIdQueryResponse ToResponse(Intervention intervention)
    {
        var response = new GetInterventionByIdQueryResponse
        {
            Id = intervention.Id,
            ReportDate = intervention.ReportDate,
            Observations = intervention.Observations,
            EvaluationDate = intervention.EvaluationDate,
            InvoiceValue = intervention.InvoiceValue,
            InterventionType = intervention.InterventionType.ToString(),
            StartDate = intervention.StartDate,
            EndDate = intervention.EndDate,
            EmployeeName = intervention.Employee.Name,
            EquipmentName = intervention.Equipment.Name
        };

        return response;
    }
}