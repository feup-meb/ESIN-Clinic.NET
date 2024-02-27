using ESIN.Clinic.CrossCutting.Features.Manufacturers;
using ESIN.Clinic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ESIN.Clinic.CrossCutting.Services;

public static class ManufacturerMapperService
{
    public static List<GetManufacturersQueryResponse> MapToResponse(this List<Manufacturer> manufacturers)
    {
        if(manufacturers.IsNullOrEmpty())
            return [];

        List<GetManufacturersQueryResponse> response = [];
        manufacturers.ToList().ForEach(x => response.Add(new GetManufacturersQueryResponse
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            MobilePhoneNumber = x.MobilePhoneNumber,
            Address = x.Address
        }));

        return response;
    }
    
    public static GetManufacturerByIdQueryResponse MapToResponse(this Manufacturer manufacturer)
    {
        var response = new GetManufacturerByIdQueryResponse
        {
            Id = manufacturer.Id,
            Name = manufacturer.Name,
            Email = manufacturer.Email,
            PhoneNumber = manufacturer.PhoneNumber,
            MobilePhoneNumber = manufacturer.MobilePhoneNumber,
            Address = manufacturer.Address
        };

        return response;
    }
}