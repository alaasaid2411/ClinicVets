using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Defines customer storage operations used by services.
/// </summary>
public interface ICustomerRepository
{
    bool ExistsByIdentityNumber(string identityNumber);
    Customer? FindByIdentityOrPhone(string searchText);
    Customer? FindById(int customerId);
    Customer Add(Customer customer);
}
