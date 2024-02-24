using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class ManufacturerService(ClinicDbContext dbContext) : IManufacturerService
{
    public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        => await dbContext.Manufacturers.ToListAsync();

    public async Task<Manufacturer?> GetManufacturerById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Manufacturer> AddManufacturer(Manufacturer manufacturer)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateManufacturer(Manufacturer manufacturer)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteManufacturerById(int id)
    {
        throw new NotImplementedException();
    }
}