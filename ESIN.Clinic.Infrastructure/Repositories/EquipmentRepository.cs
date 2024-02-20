using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;
using ESIN.Clinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class EquipmentRepository(ClinicDbContext dbContext) : IEquipmentRepository
{
    public async Task<IEnumerable<Equipment>> GetEquipments()
        => await dbContext.Equipments
            .Include(x => x.HospitalUnit)
            .Include(x => x.Manufacturer)
            .ToListAsync();

    public async Task<Equipment?> GetEquipmentById(int id)
    {
        Equipment? category = await dbContext.Equipments
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (category == default)
            throw new InvalidOperationException("Invalid data...");
        
        return category;
    }

    public async Task<Equipment> AddEquipment(Equipment equipment)
    {
        dbContext.Equipments.Add(equipment);
        await dbContext.SaveChangesAsync();
        return equipment;
    }

    public async Task UpdateEquipment(Equipment equipment)
    {
        if (equipment == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.Entry(equipment).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteEquipmentById(int id)
    {
        Equipment? equipment = await dbContext.Equipments
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (equipment == null)
            throw new InvalidOperationException("Invalid data...");

        dbContext.Equipments.Remove(equipment);
        await dbContext.SaveChangesAsync();
    }
}