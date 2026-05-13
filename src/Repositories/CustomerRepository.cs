using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Stores customer records in the current clinic data store.
/// </summary>
public class CustomerRepository(ClinicDataStore dataStore) : ICustomerRepository
{
    public bool ExistsByIdentityNumber(string identityNumber)
    {
        return dataStore.Customers.Any(customer => customer.IdentityNumber == identityNumber);
    }

    public Customer? FindByIdentityOrPhone(string searchText)
    {
        return dataStore.Customers.FirstOrDefault(customer =>
            customer.IdentityNumber == searchText || customer.Phone == searchText);
    }

    public Customer? FindById(int customerId)
    {
        return dataStore.Customers.FirstOrDefault(customer => customer.Id == customerId);
    }

    public Customer Add(Customer customer)
    {
        customer = new Customer
        {
            Id = dataStore.GetNextCustomerId(),
            FullName = customer.FullName,
            IdentityNumber = customer.IdentityNumber,
            Phone = customer.Phone,
            Email = customer.Email
        };

        dataStore.Customers.Add(customer);
        return customer;
    }
}
