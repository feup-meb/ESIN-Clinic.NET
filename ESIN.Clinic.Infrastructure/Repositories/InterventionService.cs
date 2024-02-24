using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class InterventionService(ClinicDbContext dbContext) : IInterventionService
{
    // TODO: AsSplitQuery()?
    public async Task<List<Intervention>> GetInterventions()
        => await dbContext.Interventions
            .Include(x=>x.Equipment)
            .Include(x=>x.Employee)
            .ToListAsync();

    public async Task<Intervention> GetInterventionById(int id)
    {
        Intervention? intervention = await dbContext.Interventions
            .Include(x=>x.Equipment)
            .Include(x=>x.Employee)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (intervention == default)
            throw new InvalidOperationException("Invalid data...");
        
        return intervention;
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