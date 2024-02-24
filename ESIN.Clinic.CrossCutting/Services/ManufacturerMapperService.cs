using ESIN.Clinic.CrossCutting.Manufacturers;
using ESIN.Clinic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ESIN.Clinic.CrossCutting.Services;

public static class ManufacturerMapperService
{
    public static List<GetManufacturersQueryResponse> ToResponse(List<Manufacturer> manufacturers)
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
    
    public static GetManufacturerByIdQueryResponse ToResponse(Manufacturer x)
    {
        var response = new GetManufacturerByIdQueryResponse
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            MobilePhoneNumber = x.MobilePhoneNumber,
            Address = x.Address
        };

        return response;
    }
}