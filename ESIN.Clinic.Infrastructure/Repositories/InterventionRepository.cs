using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class InterventionRepository(ClinicDbContext dbContext) : IInterventionRepository
{
    // TODO: AsSplitQuery()?
    public async Task<IEnumerable<Intervention>> GetInterventions()
        => await dbContext.Interventions
            .Include(x=>x.Equipment)
            .Include(x=>x.Employee)
            .ToListAsync();

    public async Task<Intervention?> GetInterventionById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Intervention> AddIntervention(Intervention intervention)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateIntervention(Intervention intervention)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteInterventionById(int id)
    {
        throw new NotImplementedException();
    }
}