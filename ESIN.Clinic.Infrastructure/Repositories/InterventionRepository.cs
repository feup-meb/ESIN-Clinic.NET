using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class InterventionRepository : IInterventionRepository
{
    public Task<IEnumerable<Intervention>> GetInterventions()
    {
        throw new NotImplementedException();
    }

    public Task<Intervention?> GetInterventionById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Intervention> AddIntervention(Intervention intervention)
    {
        throw new NotImplementedException();
    }

    public Task UpdateIntervention(Intervention intervention)
    {
        throw new NotImplementedException();
    }

    public Task DeleteInterventionById(int id)
    {
        throw new NotImplementedException();
    }
}