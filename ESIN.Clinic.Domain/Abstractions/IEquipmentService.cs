using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface IEquipmentService
{
    Task<List<Equipment>> GetEquipments();
    Task<Equipment> GetEquipmentById(int id);
    Task<Equipment> AddEquipment(Equipment equipment);
    Task UpdateEquipment(Equipment equipment);
    Task DeleteEquipmentById(int id);
}