using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Application.Manufacturers.Queries;

public class GetManufacturersQuery(IManufacturerService manufacturerService)
{
    public async Task<List<Manufacturer>> GetManufacturersAsync()
    {
        var manufacturers = await manufacturerService.GetManufacturers();

        if (!manufacturers.Any())
            throw new Exception("No manufacturers found.");

        return manufacturers.ToList();
    }
}