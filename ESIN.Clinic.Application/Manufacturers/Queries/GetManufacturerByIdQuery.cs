using ESIN.Clinic.CrossCutting.Features.Manufacturers;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Manufacturers.Queries;

public class GetManufacturerByIdQuery(IManufacturerRepository manufacturerRepository)
{
    public async Task<GetManufacturerByIdQueryResponse> GetCategoryByIdAsync(int id)
    {
        Manufacturer? manufacturer = await manufacturerRepository.GetManufacturerById(id);

        if (manufacturer == default)
            throw new Exception("Category not found.");

        var manufacturerResult = manufacturer.MapToResponse();
        
        return manufacturerResult;
    }
}