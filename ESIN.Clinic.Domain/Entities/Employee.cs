namespace ESIN.Clinic.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Address { get; set; }
    public required string EmployeeNumber { get; set; }
    public required string Password { get; set; }
    
    public int HospitalUnitId { get; set; }
    public required HospitalUnit HospitalUnit { get; set; }
    public int UserRoleId { get; set; }
    public required UserRole UserRole { get; set; }
}