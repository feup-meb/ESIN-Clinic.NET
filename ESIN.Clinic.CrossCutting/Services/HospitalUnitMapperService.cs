using ESIN.Clinic.CrossCutting.Features.HospitalUnits;
using ESIN.Clinic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ESIN.Clinic.CrossCutting.Services;

public static class HospitalUnitMapperService
{
    public static List<GetHospitalUnitsQueryResponse> ToResponse(List<HospitalUnit> hospitalUnits)
    {
        if(hospitalUnits.IsNullOrEmpty())
            return [];

        List<GetHospitalUnitsQueryResponse> response = [];
        hospitalUnits.ToList().ForEach(x => response.Add(new GetHospitalUnitsQueryResponse
        {
            Id = x.Id,
            Name = x.Name,
            Room = x.Room ?? string.Empty
        }));

        return response;
    }
    
    public static GetHospitalUnitByIdQueryResponse ToResponse(HospitalUnit hospitalUnit)
    {
        var response = new GetHospitalUnitByIdQueryResponse
        {
            Id = hospitalUnit.Id,
            Name = hospitalUnit.Name,
            Room = hospitalUnit.Room ?? string.Empty
        };

        return response;
    }
}