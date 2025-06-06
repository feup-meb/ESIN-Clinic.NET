using ESIN.Clinic.CrossCutting.Features.HospitalUnits;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.HospitalUnits.Queries;

public class GetHospitalUnitsQuery(IHospitalUnitRepository hospitalUnitRepository)
{
    public async Task<List<GetHospitalUnitsQueryResponse>> GetHospitalUnitsAsync()
    {
        List<HospitalUnit> hospitalUnits = await hospitalUnitRepository.GetHospitalUnits();

        if (hospitalUnits.Count == 0)
            throw new Exception("No hospital units found.");

        List<GetHospitalUnitsQueryResponse> hospitalUnitsResult = hospitalUnits.MapToResponse();
        
        return hospitalUnitsResult.ToList();
    }
}