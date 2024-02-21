using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface IManufacturerRepository
{
    Task<IEnumerable<Manufacturer>> GetManufacturers();
    Task<Manufacturer?> GetManufacturerById(int id);
    Task<Manufacturer> AddManufacturer(Manufacturer manufacturer);
    Task UpdateManufacturer(Manufacturer manufacturer);
    Task DeleteManufacturerById(int id);
}