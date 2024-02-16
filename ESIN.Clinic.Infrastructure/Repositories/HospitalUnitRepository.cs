using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class HospitalUnitRepository : IHospitalUnitRepository
{
    public Task<IEnumerable<HospitalUnit>> GetHospitalUnits()
    {
        throw new NotImplementedException();
    }

    public Task<HospitalUnit?> GetHospitalUnitById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<HospitalUnit> AddHospitalUnit(HospitalUnit hospitalUnit)
    {
        throw new NotImplementedException();
    }

    public Task UpdateHospitalUnit(HospitalUnit hospitalUnit)
    {
        throw new NotImplementedException();
    }

    public Task DeleteHospitalUnitById(int id)
    {
        throw new NotImplementedException();
    }
}