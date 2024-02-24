using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Domain.Abstractions;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee?> GetEmployeeById(int id);
    Task<Employee> AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployeeById(int id);
}