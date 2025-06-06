using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class ManufacturerRepository(ClinicDbContext dbContext) : IManufacturerRepository
{
    public async Task<List<Manufacturer>> GetManufacturers()
        => await dbContext.Manufacturers.ToListAsync();

    public async Task<Manufacturer> GetManufacturerById(int id)
    {
        Manufacturer? manufacturer = await dbContext.Manufacturers
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (manufacturer == default)
            throw new InvalidOperationException("Invalid data...");
        
        return manufacturer;
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