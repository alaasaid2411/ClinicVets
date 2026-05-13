using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Defines employee storage operations used by services.
/// </summary>
public interface IEmployeeRepository
{
    Employee? FindByUsername(string username);
    bool ExistsByRegistrationFields(string username, string employeeNumber, string email, string identityNumber);
    Employee Add(Employee employee);
}
