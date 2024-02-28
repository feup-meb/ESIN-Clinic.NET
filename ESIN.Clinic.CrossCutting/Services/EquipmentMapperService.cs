using ESIN.Clinic.CrossCutting.Features.Equipments;
using ESIN.Clinic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ESIN.Clinic.CrossCutting.Services;

public static class EquipmentMapperService
{
    public static List<GetEquipmentsQueryResponse> MapToResponse(this List<Equipment> equipments)
    {
        if(equipments.IsNullOrEmpty())
            return [];

        List<GetEquipmentsQueryResponse> response = [];
        equipments.ToList().ForEach(x => response.Add(new GetEquipmentsQueryResponse
        {
            Id = x.Id,
            SerialNumber = x.SerialNumber,
            Name = x.Name,
            Model = x.Model,
            Description = x.Description ?? string.Empty,
            AcquisitionDate = x.AcquisitionDate,
            WarrantyDate = x.WarrantyDate,
            Price = x.Price,
            IsActive = x.IsActive,
            ManufacturerName = x.Manufacturer.Name,
            CategoryName = x.Category.Name,
            HospitalUnitName = x.HospitalUnit.Name
        }));

        return response;
    }
    
    public static GetEquipmentByIdQueryResponse MapToResponse(this Equipment equipment)
    {
        var response = new GetEquipmentByIdQueryResponse
        {
            Id = equipment.Id,
            SerialNumber = equipment.SerialNumber,
            Name = equipment.Name,
            Model = equipment.Model,
            Description = equipment.Description ?? string.Empty,
            AcquisitionDate = equipment.AcquisitionDate,
            WarrantyDate = equipment.WarrantyDate,
            Price = equipment.Price,
            IsActive = equipment.IsActive,
            ManufacturerName = equipment.Manufacturer.Name,
            CategoryName = equipment.Category.Name,
            HospitalUnitName = equipment.HospitalUnit.Name
        };

        return response;
    }
}