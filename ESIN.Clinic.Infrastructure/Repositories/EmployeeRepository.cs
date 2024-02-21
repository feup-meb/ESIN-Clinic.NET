using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    public Task<IEnumerable<Employee>> GetEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<Employee?> GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeById(int id)
    {
        throw new NotImplementedException();
    }
}