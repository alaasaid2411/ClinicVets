using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Stores employee records in the current in-memory data store.
/// </summary>
public class EmployeeRepository(ClinicDataStore dataStore) : IEmployeeRepository
{
    public Employee? FindByUsername(string username)
    {
        return dataStore.Employees.FirstOrDefault(employee => employee.Username == username);
    }

    public bool ExistsByRegistrationFields(string username, string employeeNumber, string email, string identityNumber)
    {
        return dataStore.Employees.Any(employee =>
            employee.Username == username ||
            employee.EmployeeNumber == employeeNumber ||
            employee.Email == email ||
            employee.IdentityNumber == identityNumber);
    }

    public Employee Add(Employee employee)
    {
        employee = new Employee
        {
            Id = dataStore.GetNextEmployeeId(),
            Username = employee.Username,
            PasswordHash = employee.PasswordHash,
            EmployeeNumber = employee.EmployeeNumber,
            Email = employee.Email,
            IdentityNumber = employee.IdentityNumber,
            Role = employee.Role
        };

        dataStore.Employees.Add(employee);
        return employee;
    }
}
