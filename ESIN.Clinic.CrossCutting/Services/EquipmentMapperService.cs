using ESIN.Clinic.CrossCutting.Equipments;
using ESIN.Clinic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ESIN.Clinic.CrossCutting.Services;

public static class EquipmentMapperService
{
    public static List<GetEquipmentsQueryResponse> ToResponse(List<Equipment> equipments)
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
            Manufacturer = x.Manufacturer.Name,
            Category = x.Category.Name,
            HospitalUnit = x.HospitalUnit.Name
        }));

        return response;
    }
    
    public static GetEquipmentByIdQueryResponse ToResponse(Equipment equipment)
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
            Manufacturer = equipment.Manufacturer.Name,
            Category = equipment.Category.Name,
            HospitalUnit = equipment.HospitalUnit.Name
        };

        return response;
    }
}