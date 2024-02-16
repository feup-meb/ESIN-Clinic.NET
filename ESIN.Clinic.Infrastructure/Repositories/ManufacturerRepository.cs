using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class ManufacturerRepository : IManufacturerRepository
{
    public Task<IEnumerable<Manufacturer>> GetManufacturers()
    {
        throw new NotImplementedException();
    }

    public Task<Manufacturer?> GetManufacturerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Manufacturer> AddManufacturer(Manufacturer manufacturer)
    {
        throw new NotImplementedException();
    }

    public Task UpdateManufacturer(Manufacturer manufacturer)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManufacturerById(int id)
    {
        throw new NotImplementedException();
    }
}