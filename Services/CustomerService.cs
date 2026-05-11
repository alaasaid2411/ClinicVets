using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Services;

public class CustomerService(ClinicDataStore dataStore)
{
    public OperationResult<Customer> RegisterCustomer(
        StaffMember currentUser,
        string fullName,
        string identityNumber,
        string phone,
        string email)
    {
        if (currentUser.Role != StaffRole.Secretary)
        {
            return OperationResult<Customer>.Failure("Only a secretary can register customers.");
        }

        if (!InputValidator.IsEnglishOrHebrewName(fullName))
        {
            return OperationResult<Customer>.Failure("Full name must contain letters only.");
        }

        if (!InputValidator.IsIdentityNumberValid(identityNumber))
        {
            return OperationResult<Customer>.Failure("Identity number must contain exactly 9 digits.");
        }

        if (!InputValidator.IsPhoneValid(phone) || !InputValidator.IsEmailValid(email))
        {
            return OperationResult<Customer>.Failure("Phone or email format is invalid.");
        }

        if (dataStore.Customers.Any(customer => customer.IdentityNumber == identityNumber))
        {
            return OperationResult<Customer>.Failure("Customer identity number already exists.");
        }

        Customer customer = new()
        {
            Id = dataStore.GetNextCustomerId(),
            FullName = fullName,
            IdentityNumber = identityNumber,
            Phone = phone,
            Email = email
        };

        dataStore.Customers.Add(customer);
        return OperationResult<Customer>.Success(customer);
    }

    public Customer? SearchByIdentityOrPhone(string searchText)
    {
        return dataStore.Customers.FirstOrDefault(customer =>
            customer.IdentityNumber == searchText || customer.Phone == searchText);
    }

    public IReadOnlyList<Pet> GetCustomerPets(int customerId)
    {
        return dataStore.Pets.Where(pet => pet.OwnerCustomerId == customerId).ToList();
    }
}
