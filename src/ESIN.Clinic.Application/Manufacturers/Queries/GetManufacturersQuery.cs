using ESIN.Clinic.CrossCutting.Features.Manufacturers;
using ESIN.Clinic.CrossCutting.Services;
using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Manufacturers.Queries;

public class GetManufacturersQuery(IManufacturerRepository manufacturerRepository)
{
    public async Task<List<GetManufacturersQueryResponse>> GetManufacturersAsync()
    {
        List<Manufacturer> manufacturers = await manufacturerRepository.GetManufacturers();

        if (manufacturers.Count == 0)
            throw new Exception("No manufacturers found.");

        List<GetManufacturersQueryResponse> manufacturersResult = manufacturers.MapToResponse();

        return manufacturersResult.ToList();
    }
}