using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class HospitalUnitRepository(ClinicDbContext dbContext) : IHospitalUnitRepository
{
    public async Task<List<HospitalUnit>> GetHospitalUnits()
        => await dbContext.HospitalUnits.ToListAsync();

    public async Task<HospitalUnit> GetHospitalUnitById(int id)
    {
        HospitalUnit? hospitalUnit = await dbContext.HospitalUnits
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (hospitalUnit == default)
            throw new InvalidOperationException("Invalid data...");
        
        return hospitalUnit;
    }

    public async Task<HospitalUnit> AddHospitalUnit(HospitalUnit hospitalUnit)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateHospitalUnit(HospitalUnit hospitalUnit)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteHospitalUnitById(int id)
    {
        throw new NotImplementedException();
    }
}