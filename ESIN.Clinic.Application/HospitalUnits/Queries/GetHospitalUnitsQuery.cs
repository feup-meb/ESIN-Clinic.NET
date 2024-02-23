using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.HospitalUnits.Queries;

public class GetHospitalUnitsQuery(IHospitalUnitRepository hospitalUnitRepository)
{
    public async Task<List<HospitalUnit>> GetHospitalUnitsAsync()
    {
        var hospitalUnits = await hospitalUnitRepository.GetHospitalUnits();

        if (!hospitalUnits.Any())
            throw new Exception("No hospital units found.");

        return hospitalUnits.ToList();
    }
}