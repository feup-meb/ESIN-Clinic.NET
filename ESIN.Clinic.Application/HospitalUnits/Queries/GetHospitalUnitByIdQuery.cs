using ESIN.Clinic.CrossCutting.Features.HospitalUnits;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.HospitalUnits.Queries;

public class GetHospitalUnitByIdQuery(IHospitalUnitRepository hospitalUnitRepository)
{
    public async Task<GetHospitalUnitByIdQueryResponse> GetHospitalUnitByIdAsync(int id)
    {
        HospitalUnit? hospitalUnit = await hospitalUnitRepository.GetHospitalUnitById(id);

        if (hospitalUnit == default)
            throw new Exception("Hospital Unit not found.");

        GetHospitalUnitByIdQueryResponse hospitalUnitResult = hospitalUnit.MapToResponse();
        
        return hospitalUnitResult;
    }
}