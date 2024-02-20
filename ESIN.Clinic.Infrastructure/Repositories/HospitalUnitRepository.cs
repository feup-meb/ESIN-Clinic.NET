using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class HospitalUnitRepository(ClinicDbContext dbContext) : IHospitalUnitRepository
{
    public async Task<IEnumerable<HospitalUnit>> GetHospitalUnits()
        => await dbContext.HospitalUnits.ToListAsync();

    public async Task<HospitalUnit?> GetHospitalUnitById(int id)
    {
        throw new NotImplementedException();
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