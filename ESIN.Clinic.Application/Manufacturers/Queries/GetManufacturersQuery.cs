using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Manufacturers.Queries;

public class GetManufacturersQuery(IManufacturerRepository manufacturerRepository)
{
    public async Task<List<Manufacturer>> GetManufacturersAsync()
    {
        var manufacturers = await manufacturerRepository.GetManufacturers();

        if (!manufacturers.Any())
            throw new Exception("No manufacturers found.");

        return manufacturers.ToList();
    }
}