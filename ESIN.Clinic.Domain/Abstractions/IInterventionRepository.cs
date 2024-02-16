using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface IInterventionRepository
{
    Task<IEnumerable<Intervention>> GetInterventions();
    Task<Intervention?> GetInterventionById(int id);
    Task<Intervention> AddIntervention(Intervention intervention);
    Task UpdateIntervention(Intervention intervention);
    Task DeleteInterventionById(int id);
}