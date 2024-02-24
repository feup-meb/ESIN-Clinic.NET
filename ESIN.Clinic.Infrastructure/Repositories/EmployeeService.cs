using ESIN.Clinic.Domain.Abstractions;
using ESIN.Clinic.Domain.Entities;

namespace ESIN.Clinic.Infrastructure.Repositories;

public class EmployeeService : IEmployeeService
{
    public async Task<List<Employee>> GetEmployees()
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteEmployeeById(int id)
    {
        throw new NotImplementedException();
    }
}