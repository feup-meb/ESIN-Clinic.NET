namespace ESIN.Clinic.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? Address { get; set; }
    public string EmployeeNumber { get; set; }
    public string Password { get; set; }
    
    public int HospitalUnitId { get; set; }
    public int UserTypeId { get; set; }
}