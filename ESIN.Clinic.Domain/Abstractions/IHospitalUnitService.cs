using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface IHospitalUnitService
{
    Task<List<HospitalUnit>> GetHospitalUnits();
    Task<HospitalUnit> GetHospitalUnitById(int id);
    Task<HospitalUnit> AddHospitalUnit(HospitalUnit hospitalUnit);
    Task UpdateHospitalUnit(HospitalUnit hospitalUnit);
    Task DeleteHospitalUnitById(int id);
}