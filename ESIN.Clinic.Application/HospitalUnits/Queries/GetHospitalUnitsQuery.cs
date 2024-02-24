using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.HospitalUnits.Queries;

public class GetHospitalUnitsQuery(IHospitalUnitService hospitalUnitService)
{
    public async Task<List<HospitalUnit>> GetHospitalUnitsAsync()
    {
        var hospitalUnits = await hospitalUnitService.GetHospitalUnits();

        if (!hospitalUnits.Any())
            throw new Exception("No hospital units found.");

        return hospitalUnits.ToList();
    }
}